import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { MatSort } from '@angular/material/sort';

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
  displayedColumns: string[] = ['select', 'name', 'time', 'priority'];
  dataSource: MatTableDataSource<PeriodicElement>;

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  selection = new SelectionModel<PeriodicElement>(true, []);


  constructor() {
    this.dataSource = new MatTableDataSource(ELEMENT_DATA);
  }

  ngOnInit() {
    this.dataSource.sort = this.sort;
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}