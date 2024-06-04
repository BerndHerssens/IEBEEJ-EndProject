import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { UserService } from '../services/user.service';
import { provideNativeDateAdapter } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
  standalone: true,
  providers: [provideNativeDateAdapter()],
  imports: [MatFormFieldModule, MatInputModule, MatDatepickerModule, FormsModule, ReactiveFormsModule],
  
})
export class RegisterComponent {
  registerForm = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    adress: new FormControl(''),
    phoneNumber: new FormControl(''),
    birthday: new FormControl(''),
  });

  constructor(private userService : UserService) {}

  register() : void{
    console.log(this.registerForm.value)
    this.userService.registerAUser(this.registerForm.value).subscribe(
      (data) => {
        this.userService.currentUser = data;
      }, 
        (error) => {
          console.error(error)
          alert("Wrong username or password")
        }
      
    )
  }
}
