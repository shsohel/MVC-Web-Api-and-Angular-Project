import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { JobapplyService } from 'src/app/shared/jobapplyinfo/jobapply.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-jobapply-form',
  templateUrl: './jobapply-form.component.html',
  styleUrls: ['./jobapply-form.component.css']
})
export class JobapplyFormComponent implements OnInit {
  constructor(private service: JobapplyService, private authService: AuthService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
    form.resetForm();
    }
    this.service.formData = {
      ApplyJobID: null,
      JobListID: null,
      PersonalDetailID: null,
    };
  }

onSubmit(form: NgForm) {
  if (form.value.ApplyJobID == null) {
  this.insertRecord(form);
  } else {
  this.updateRecord(form);
  }
}

insertRecord(form: NgForm) {
  this.service.postApplyJob(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
updateRecord(form: NgForm) {
  this.service.putApplyJob(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
}
