import { HttpClient } from '@angular/common/http';
import { Injectable, Signal } from '@angular/core';
import { BehaviorSubject, Subject, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  url = 'api';
  isLoggedIn$ = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) { }

  login(username: string, password: string, persist: boolean) {
    return this.http.post(`${this.url}/login`, {
      username,
      password,
      persist
    }, {
      observe: 'response'
    }).pipe(
      tap((x) => {
        this.isLoggedIn$.next(true);
      })
    )
  }

  getUser() {
    return this.http.get(`${this.url}/login/userInfo`);
  }
}
