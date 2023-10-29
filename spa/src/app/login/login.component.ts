import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BackendService } from '../backend.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  loginForm = new FormBuilder().group({
    username: ['', Validators.required],
    password: ['', Validators.required],
    persist: [false]
  });
  isLoading = false;

  constructor(private backendService: BackendService) {
  }

  onLoginClicked() {
    const value = this.loginForm.value;
    this.isLoading = true;
    this.backendService.login(value.username ?? '', value.password ?? '', value.persist ?? false).subscribe(() => {
      this.isLoading = false;
      console.log('sweeeet');
    }, (err) => {
      this.isLoading = false;
      console.error('drat');
    });
  }
}
