import { Component, OnInit } from '@angular/core';
import { ExperiencedetailsService } from 'src/app/shared/experienceinfo/experiencedetails.service';
import { AuthService } from 'src/app/auth/auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-experience-form',
  templateUrl: './experience-form.component.html',
  styleUrls: ['./experience-form.component.css']
})
export class ExperienceFormComponent implements OnInit {
  constructor(private service: ExperiencedetailsService, private authService: AuthService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
    form.resetForm();
    }
    this.service.formData = {
      ExperienceID: null,
      CompanyName: '',
      CompnayBusiness: '',
      CompanyLocation: '',
      Designation: '',
      Department: '',
      Responsibilities: '',
      StartDate: null,
      EndDate: null,
      IsContinue: null,
      PersonalDetailID: null,
    };
  }

onSubmit(form: NgForm) {
  if (form.value.ExperienceID == null) {
  this.insertRecord(form);
  } else {
  this.updateRecord(form);
  }
}

insertRecord(form: NgForm) {
  this.service.postExperience(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
updateRecord(form: NgForm) {
  this.service.putExperience(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
}
