import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddTaskResponse } from './responses/add-task.response';
import { DailyTasksRespone } from './responses/tasks-per-user.response';
import { TaskDoneResponse } from './responses/task-done.response';

@Injectable()
export class TrackerService {
    constructor(
        private httpClient: HttpClient) { }

    addTask(addTaskForm): Observable<AddTaskResponse> {
        return this.httpClient.post<AddTaskResponse>('api/Task/AddTask', addTaskForm);
    }

    dailyTasks(): Observable<DailyTasksRespone> {
        return this.httpClient.get<DailyTasksRespone>('api/Task/DailyTasks');
    }

    taskDone(taskId: number): Observable<TaskDoneResponse> {
        return this.httpClient.post<TaskDoneResponse>('api/Task/TaskDone', taskId);
    }
}