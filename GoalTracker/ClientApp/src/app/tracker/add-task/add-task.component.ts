import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RoutingService } from 'src/app/_shared/services/routing.service';
import { TrackerService } from '../tracker.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { SnackBarService } from 'src/app/_shared/services/snackbar.service';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.scss']
})
export class AddTaskComponent implements OnInit, OnDestroy {
  today: number = Date.now();
  public selectedTime = '19:00';
  isLoading: boolean = false;
  addTaskForm: FormGroup;
  private _unsubscribeAll: Subject<any>;

  constructor(
    private _formBuilder: FormBuilder,
    private _routingService: RoutingService,
    private _trackerService: TrackerService,
    private _snackBarService: SnackBarService) {
    this._unsubscribeAll = new Subject();
  }

  ngOnInit(): void {
    this.addTaskForm = this._formBuilder.group({
      date: [new Date().toUTCString()],
      title: [null, Validators.required],
      priority: [null, Validators.required],
      taskStartTime: ["09:30"],
      taskEndTime: ["18:30"]
    });
  }

  addTask() {
    console.log(this.addTaskForm.value);

    this._trackerService
      .addTask(this.addTaskForm.value)
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(result => {

        this._snackBarService.openSnackBar([result.message], 4000, 'center', 'center', 'success');
        this._routingService.navigate('tracker/dailytasks');
      });
  }

  ngOnDestroy(): void {
    this._unsubscribeAll.next();
    this._unsubscribeAll.complete();
  }
}