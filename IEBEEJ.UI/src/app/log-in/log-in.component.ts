import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrl: './log-in.component.css'
})
export class LogInComponent {
  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private userService : UserService) {}

  login() : void{

    let obj = this.loginForm.value;
    this.userService.getUserByLogin(obj.username!, obj.password!).subscribe(
      (data) => {
        this.userService.currentUser = data;
      }, 
        (error) => {
          alert("Wrong username or password")
        }
      
    )
  }
}
