import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  loginForm = new FormBuilder().group({
    username: ['', Validators.required],
    password: ['', Validators.required],
    persist: [false],
  });
  isLoading = false;

  constructor(private authService: AuthenticationService) {}

  onLoginClicked() {
    const value = this.loginForm.value;
    this.isLoading = true;
    this.authService
      .login(value.username ?? '', value.password ?? '', value.persist ?? false)
      .subscribe(
        () => {
          this.isLoading = false;
          console.log('sweeeet');
        },
        (err) => {
          this.isLoading = false;
          console.error('drat');
        }
      );
  }
}
