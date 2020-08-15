export interface DailyTasksRespone {
    dailyTasks: Task[]
}

export interface Task {
    id: number,
    date: Date
    title: string,
    priority: number,
    taskStartTime: string,
    taskEndTime: string
}