import { Component } from '@angular/core';
import { BackendService } from '../backend.service';
import { Post } from '../models/posts';
import { RouteNames } from '../app-routing.module';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss']
})
export class PostsComponent {

  posts?: Post[];

  constructor(private backendService: BackendService) {

  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.

    this.backendService.getPosts().subscribe(x => this.posts = x);
  }

  get RouteNames() {
    return RouteNames;
  }
}
