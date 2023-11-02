import { WeatherForecast } from './models/weather-forecast';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { WeatherForecastsComponent } from './weather-forecasts/weather-forecasts.component';
import { UserInfoComponent } from './user-info/user-info.component';

export class RouteNames {
  static UserInfo = 'userInfo';
  static Login = 'login';
  static WeatherForecast = 'weatherForecasts';
}

const routes: Routes = [
  {
    path: RouteNames.Login,
    component: LoginComponent,
  },
  {
    path: RouteNames.WeatherForecast,
    component: WeatherForecastsComponent
  },
  {
    path: RouteNames.UserInfo,
    component: UserInfoComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
