import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ITask } from 'src/app/models/task';
import { IUpdate } from 'src/app/models/update';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private baseUrl: string = "https://localhost:5000/api/tasks";

  constructor(private http: HttpClient) { }

  getTasks(userId: number) : Observable<ITask[]>{
    return this.http.get<ITask[]>(this.baseUrl+`/users/`+userId);
  }

  createTask(task: ITask) : Observable<boolean>{
    return this.http.post<boolean>(this.baseUrl, task)
  }

  deleteTask(id: number) : Observable<void> {
    const url = `${this.baseUrl}/${id}`; // add the ID to the base URL
    return this.http.delete<void>(url);
  }

  updateTask(dto: IUpdate, id: number) : Observable<void> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.put<void>(url, dto)
  }
}
