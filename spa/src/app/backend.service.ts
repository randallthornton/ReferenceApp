import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { WeatherForecast } from './models/weather-forecast';

@Injectable({
  providedIn: 'root',
})
export class BackendService {
  url = 'api';

  constructor(private http: HttpClient) { }

  fetchWeatherForecasts() {
    return this.http.get<WeatherForecast[]>(`${this.url}/weatherForecast`);
  }

  login(username: string, password: string, persist: boolean) {
    return this.http.post(`${this.url}/login`, {
      username,
      password,
      persist
    })
  }
}
