import { Component, OnInit } from '@angular/core';
import { TrainingdetailsService } from 'src/app/shared/traininginfo/trainingdetails.service';
import { AuthService } from 'src/app/auth/auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-training-form',
  templateUrl: './training-form.component.html',
  styleUrls: ['./training-form.component.css']
})
export class TrainingFormComponent implements OnInit {

  constructor(private service: TrainingdetailsService, private authService: AuthService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
    form.resetForm();
    }
    this.service.formData = {
      TrainingID: null,
      Title: '',
      Topics: '',
      Institute: '',
      Location: '',
      Country: '',
      TrainingYear: '',
      Duration: '',
      PersonalDetailID: null,
    };
}

onSubmit(form: NgForm) {
  if (form.value.TrainingID == null) {
  this.insertRecord(form);
  } else {
  this.updateRecord(form);
  }
}

insertRecord(form: NgForm) {
  this.service.postTraining(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
updateRecord(form: NgForm) {
  this.service.putTraining(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
}
