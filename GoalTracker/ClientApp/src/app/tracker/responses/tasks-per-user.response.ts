import { BaseResponse } from 'src/app/_shared/responses/baseResponse';

export interface TasksPerUserRespone extends BaseResponse {
    dailyTasks: Task[]
}

export interface Task {
    date: Date
    title: string,
    priority: number,
    taskStartTime: string,
    taskEndTime: string
}