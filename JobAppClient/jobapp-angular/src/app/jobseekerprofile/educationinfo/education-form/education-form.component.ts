import { Component, OnInit } from '@angular/core';
import { EducationdetailsService } from 'src/app/shared/educationinfo/educationdetails.service';
import { AuthService } from 'src/app/auth/auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-education-form',
  templateUrl: './education-form.component.html',
  styleUrls: ['./education-form.component.css']
})
export class EducationFormComponent implements OnInit {

  constructor(private service: EducationdetailsService, private authService: AuthService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
    form.resetForm();
    }
    this.service.formData = {
      EducationID: null,
      LevelOfEducation: '',
      CGPA : '',
      Scale : '' ,
      DegreeTitle : '',
      Group: '',
      Institute: '',
      PassingYear: '',
      Duration : '',
      Achievement : '',
      PersonalDetailID: null
    };
}

onSubmit(form: NgForm) {
  if (form.value.EducationID == null) {
  this.insertRecord(form);
  } else {
  this.updateRecord(form);
  }
}

insertRecord(form: NgForm) {
  this.service.postEducation(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
updateRecord(form: NgForm) {
  this.service.putEducations(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
}
