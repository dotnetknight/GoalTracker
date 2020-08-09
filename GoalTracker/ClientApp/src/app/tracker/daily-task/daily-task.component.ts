import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { MatSort } from '@angular/material/sort';
import { RoutingService } from 'src/app/_shared/services/routing.service';
import { TrackerService } from '../tracker.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { SnackBarService } from 'src/app/_shared/services/snackbar.service';
import { TasksPerUserRespone, Task } from '../responses/tasks-per-user.response';

export interface PeriodicElement {
  name: string;
  time: string;
  priority: number;
}
const ELEMENT_DATA: PeriodicElement[] = [
  { name: 'თასქის გაცნობა', time: '10:00 - 10:20', priority: 3 },
  { name: 'Debug', time: '11:00 - 12:30', priority: 5 },
  { name: 'დასვენება', time: '12:30 - 13:30', priority: 2 },
  { name: 'Debug', time: '13:30 - 15:30', priority: 5 },
  { name: 'დასვენება', time: '15:30 - 15:50', priority: 2 },
  { name: 'Debug', time: '15:50 - 17:30', priority: 5 },
  { name: 'დასვენება', time: '17:30 - 17:45', priority: 2 },
  { name: 'Debug', time: '17:45 - 19:10', priority: 5 }
];
@Component({
  selector: 'app-daily-task',
  templateUrl: './daily-task.component.html',
  styleUrls: ['./daily-task.component.scss']
})
export class DailyTaskComponent implements OnInit {
  displayedColumns: string[] = ['select', 'title', 'time', 'priority'];
  dataSource: MatTableDataSource<Task>;

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  selection = new SelectionModel<TasksPerUserRespone>(true, []);

  private _unsubscribeAll: Subject<any>;
  isLoading: boolean = true;


  constructor(
    private _routingService: RoutingService,
    private _trackerService: TrackerService,
    private _snackBarService: SnackBarService) {
    // this.dataSource = new MatTableDataSource(ELEMENT_DATA);
    this._unsubscribeAll = new Subject();
  }

  ngOnInit() {
    this._trackerService
      .dailyTasks()
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(result => {
        console.log("RESULT", result);

        this.dataSource = new MatTableDataSource(result.dailyTasks);
        this.dataSource.sort = this.sort;
        this.isLoading = false;

      }, err => {
        if (err.error.errors != undefined) {
          this._snackBarService
            .openSnackBar(err.error.errors
              .map(element => element.message), 4000, 'center', 'center', 'error');
        }

        else {
          this._snackBarService
            .openSnackBar([err.error.message], 4000, 'center', 'center', 'error');
        }
      });

  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select());
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  addTask() {
    this._routingService.navigate("tracker/addtask");
  }
}