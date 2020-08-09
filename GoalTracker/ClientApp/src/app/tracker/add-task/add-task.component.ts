import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RoutingService } from 'src/app/_shared/services/routing.service';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.scss']
})
export class AddTaskComponent implements OnInit {
  today: number = Date.now();
  public selectedTime = '19:00';
  isLoading: boolean = false;
  addTaskForm: FormGroup;

  constructor(private _formBuilder: FormBuilder,
    private _routingService: RoutingService) { }

  ngOnInit(): void {
    this.addTaskForm = this._formBuilder.group({
      date: [new Date().toUTCString()],
      title: [null, Validators.required],
      priority: [null, Validators.required],
      goalToTime: ["18:30"],
      goalFromTime: ["09:30"]
    });
  }

  addTask() {
    console.log("TASK FORM:", this.addTaskForm.value);
    this._routingService.navigate('tracker/dailytasks');
  }
}