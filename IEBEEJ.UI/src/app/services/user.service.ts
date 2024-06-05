import { Injectable } from '@angular/core';
import { UserDTO } from '../DTOs/users';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private APIUrl = 'https://localhost:7128/api/User'
  isLoggedIn: boolean = false;

  currentUser: any = {
    id: 1,
    name: "Buddy",
    email: "Buddy@hotmail.com",
    password: "1230",
    adress: "Thuis-Straat",
    phoneNumber: "1234567890",
    birthday: new Date(1980, 9, 10)
  }

  getUserByLogin(username: string, password: string) : Observable<any> {
    return this.httpClient.get(`${this.APIUrl}/UserLogin?username=${username}&password=${password}`)
  }

  registerAUser(user: any) : Observable<any> {
    return this.httpClient.post(`${this.APIUrl}/CreateUser`, user)
  }
  constructor(private httpClient: HttpClient) {}
}
