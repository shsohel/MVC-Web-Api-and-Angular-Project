import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { JobseekerregistraionService } from 'src/app/shared/jobseeker/jobseekerregistraion.service';

@Component({
  selector: 'app-jslogin-form',
  templateUrl: './jslogin-form.component.html',
  styles: []
})
export class JsloginFormComponent implements OnInit {
  isLoginError: Boolean = false;
  constructor(private userService: JobseekerregistraionService, private router: Router) { }

  ngOnInit() {
  }
  OnSubmit(userName, password) {
    this.userService.userAuthentication(userName, password).subscribe((data: any) => {
     localStorage.setItem('userToken', data.access_token);
     this.router.navigate(['/dashboard/jobseekerdashboard/pinfo']);
   },
   (err: HttpErrorResponse) => {
     this.isLoginError = true;
   });
 }

}

