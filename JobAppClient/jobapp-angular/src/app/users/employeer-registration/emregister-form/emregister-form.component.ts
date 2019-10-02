import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { JobseekerregistraionService } from 'src/app/shared/jobseeker/jobseekerregistraion.service';
import { Router } from '@angular/router';
import { EmployerregistrationService } from 'src/app/shared/employer/employerregistration.service';

@Component({
  selector: 'app-emregister-form',
  templateUrl: './emregister-form.component.html',
  styleUrls: ['./emregister-form.component.css']
})
export class EmregisterFormComponent implements OnInit {

  constructor(private service: EmployerregistrationService, private router: Router) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
    form.resetForm();
    }
    this.service.formData = {
      UserName: '',
      Email : '',
      Password : '',
      ConfirmPassword: '',
    //  UserRoles: ''
    };
}

onSubmit(form: NgForm) {
  this.insertRecord(form);
  this.router.navigate(['/home']);
  }
  insertRecord(form: NgForm) {
    this.service.postJobemp(form.value).subscribe(res => {
      this.resetForm(form);
      console.log(form);
    });
  }


}
