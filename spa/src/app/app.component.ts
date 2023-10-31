import { Component } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'spa';
  isLoggedIn$: Observable<boolean>;

  public constructor(
    private authService: AuthenticationService,
    private router: Router
  ) {
    this.isLoggedIn$ = authService.isLoggedIn$;
  }

  onLogoutClicked() {
    this.authService.logout().subscribe(() => {
      this.router.navigate(['/login']);
    });
  }
}
