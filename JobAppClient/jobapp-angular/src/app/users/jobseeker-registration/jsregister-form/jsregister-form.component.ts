import { Component, OnInit } from '@angular/core';
import { JobseekerregistraionService } from 'src/app/shared/jobseeker/jobseekerregistraion.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-jsregister-form',
  templateUrl: './jsregister-form.component.html',
  styleUrls: ['./jsregister-form.component.css']
})
export class JsregisterFormComponent implements OnInit {
  constructor(private service: JobseekerregistraionService, private router: Router) { }

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
    this.service.postJob(form.value).subscribe(res => {
      this.resetForm(form);
      console.log(form);
    });
  }

/*
  onSubmit() {
    if (this.service.formData.UserName === 'JobSeeker') {
      this.traineeService.update(this.trainee, this.trainee.id)
        .subscribe(x => {
          console.log(x),
            this.router.navigate(['/trainee'])
        });
    }
    else {
      console.log(this.trainee);
      this.traineeService.create(this.trainee)
        .subscribe(x => {
          console.log(x),
            this.router.navigate(['/trainee'])
        });
    }
  }

*/
}






