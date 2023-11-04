import { WeatherForecast } from './models/weather-forecast';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { WeatherForecastsComponent } from './weather-forecasts/weather-forecasts.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { PostsComponent } from './posts/posts.component';
import { CreatePostComponent } from './create-post/create-post.component';

export class RouteNames {
  static UserInfo = 'userInfo';
  static Login = 'login';
  static WeatherForecast = 'weatherForecasts';
  static Posts = 'posts';
  static CreatePost = 'createPost';
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
  },
  {
    path: RouteNames.Posts,
    component: PostsComponent
  },
  {
    path: RouteNames.CreatePost,
    component: CreatePostComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
