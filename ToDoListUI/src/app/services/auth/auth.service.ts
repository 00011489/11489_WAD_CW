import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl: string = "https://localhost:5000/api/users/";

  constructor(private http: HttpClient) { }

  signup(registerObj:any){
    return this.http.post<any>(`${this.baseUrl}register`, registerObj)
  }
  
  login(loginObj:any){
    return this.http.post<any>(`${this.baseUrl}authenticate`, loginObj)
  }
  


}
