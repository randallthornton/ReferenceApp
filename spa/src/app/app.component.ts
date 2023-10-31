import { Component } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'spa';
  isLoggedIn$: Observable<boolean>

  public constructor(private authService: AuthenticationService) {
    this.isLoggedIn$ = authService.isLoggedIn$.asObservable();
  }
}
