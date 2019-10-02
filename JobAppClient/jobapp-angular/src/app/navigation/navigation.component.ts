import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JobseekerregistraionService } from '../shared/jobseeker/jobseekerregistraion.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  authService: any;

  constructor(private userService: JobseekerregistraionService,   private router: Router) { }

  ngOnInit() {
  }


  Logout() {
    localStorage.removeItem('userToken');
    this.router.navigate(['/jsregister/login']);
  }


  isLoggedIn() {
    if (localStorage.getItem('userToken')) {
      return true;
    }
    return false;
}

}
