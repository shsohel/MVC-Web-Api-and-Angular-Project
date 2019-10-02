import { Component, OnInit } from '@angular/core';
import { JobseekerregistraionService } from 'src/app/shared/jobseeker/jobseekerregistraion.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-emlogin-form',
  templateUrl: './emlogin-form.component.html',
  styleUrls: ['./emlogin-form.component.css']
})
export class EmloginFormComponent implements OnInit {

  isLoginError: Boolean = false;
  constructor(private userService: JobseekerregistraionService, private router: Router) { }

  ngOnInit() {
  }
  OnSubmit(userName, password) {
    this.userService.userAuthentication(userName, password).subscribe((data: any) => {
     localStorage.setItem('userToken', data.access_token);
     this.router.navigate(['/dashboard/employeer/emplInf']);
   },
   (err: HttpErrorResponse) => {
     this.isLoginError = true;
   });
 }

}
