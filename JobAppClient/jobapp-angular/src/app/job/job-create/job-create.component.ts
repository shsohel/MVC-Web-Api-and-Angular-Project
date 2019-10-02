import { Component, OnInit } from '@angular/core';
import { JoblistService } from 'src/app/shared/job/joblist.service';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/auth/auth.service';
import { Employeerinfo } from 'src/app/shared/employeerinfo/employeerinfo.model';
import { EmployeerinfoService } from 'src/app/shared/employeerinfo/employeerinfo.service';

@Component({
  selector: 'app-job-create',
  templateUrl: './job-create.component.html',
  styleUrls: ['./job-create.component.css']
})
export class JobCreateComponent implements OnInit {
  employeer: Employeerinfo[];

  constructor(private service: JoblistService, private emplservice: EmployeerinfoService, private authService: AuthService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
    form.resetForm();
    }
    this.service.formData = {
      JobListID: null,
      EmployerID: null,
      Position : '',
      NumberofPost : null ,
      SalaryScale : '',
      AgeLimit : '',
      EducationRequirement: '',
      LastDateofApplication: null,
      IsApprove : null,

    };
}

onSubmit(form: NgForm) {
  if (form.value.JobListID == null) {
  this.insertRecord(form);
  } else {
  this.updateRecord(form);
  }
}

insertRecord(form: NgForm) {
  this.service.postJob(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
updateRecord(form: NgForm) {
  this.service.putJoblist(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
}
