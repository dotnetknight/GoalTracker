import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddTaskResponse } from './responses/add-task.response';

@Injectable()
export class TrackerService {
    constructor(
        private httpClient: HttpClient) { }

    addTask(addTaskForm): Observable<AddTaskResponse> {
        return this.httpClient.post<AddTaskResponse>('api/Task/AddTask', addTaskForm);
    }
}