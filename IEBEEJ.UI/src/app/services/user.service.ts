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
    Id: 1,
    Name: "Buddy",
    Email: "Buddy@hotmail.com",
    Password: "1230",
    Address: "Thuis-Straat",
    PhoneNumber: "1234567890",
    Birthday: new Date(1980, 9, 10)
  }

  getUserByLogin(username: string, password: string) : Observable<any> {
    return this.httpClient.get(`${this.APIUrl}/UserLogin?username=${username}&password=${password}`)
  }
  constructor(private httpClient: HttpClient) {}
}
