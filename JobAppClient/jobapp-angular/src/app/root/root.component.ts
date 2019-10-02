import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css']
})
export class RootComponent implements OnInit {

  constructor(private routes: Router) { }

  ngOnInit() {
  }

  UseMvc() {
    this.routes.navigate(['/jsregister/login']);
    sessionStorage.setItem('url', 'http://localhost:51654/api');
    localStorage.setItem('url', 'http://localhost:51654/api');
  }

  UseCore() {
    this.routes.navigate(['/jsregister/login']);
    sessionStorage.setItem('url', 'http://localhost:50382/api');
    localStorage.setItem('url', 'http://localhost:50382/api');
  }
}
