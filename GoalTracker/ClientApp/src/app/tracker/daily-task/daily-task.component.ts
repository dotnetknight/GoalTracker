import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { RoutingService } from 'src/app/_shared/services/routing.service';
import { TrackerService } from '../tracker.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { SnackBarService } from 'src/app/_shared/services/snackbar.service';
import { Task } from '../responses/tasks-per-user.response';

@Component({
  selector: 'app-daily-task',
  templateUrl: './daily-task.component.html',
  styleUrls: ['./daily-task.component.scss']
})

export class DailyTaskComponent implements OnInit {
  private _unsubscribeAll: Subject<any>;
  displayedColumns: string[] = ['done', 'title', 'time', 'priority'];
  dataSource: MatTableDataSource<Task>;
  isLoading: boolean = true;

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private _routingService: RoutingService,
    private _trackerService: TrackerService,
    private _snackBarService: SnackBarService) {
    this._unsubscribeAll = new Subject();
  }

  ngOnInit() {
    this._trackerService
      .dailyTasks()
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(result => {
        this.dataSource = new MatTableDataSource(result.dailyTasks);
        this.dataSource.sort = this.sort;
        this.isLoading = false;
      });
  }

  goalMarkedAsDone(row, event) {
    this._trackerService
      .taskDone(row.id, event.checked)
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(result => {

        this._snackBarService.openSnackBar([result.message], 4000, 'center', 'center', 'success');
        this.isLoading = false;
      });
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