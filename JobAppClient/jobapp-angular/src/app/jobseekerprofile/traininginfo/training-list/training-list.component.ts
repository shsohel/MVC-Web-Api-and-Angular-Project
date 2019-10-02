import { Component, OnInit } from '@angular/core';
import { TrainingdetailsService } from 'src/app/shared/traininginfo/trainingdetails.service';
import { Training } from 'src/app/shared/traininginfo/training.model';

@Component({
  selector: 'app-training-list',
  templateUrl: './training-list.component.html',
  styleUrls: ['./training-list.component.css']
})
export class TrainingListComponent implements OnInit {
  rootURl = localStorage.getItem('url');
  constructor(private service: TrainingdetailsService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(details: Training) {
    this.service.formData = Object.assign({}, details);
  }

  onDelete(id: any) {
    if (confirm('Are You Sure??')) {
      console.log(id);
      this.service.deleteTraining(id).subscribe(x => {
        console.log(x), this.service.refreshList();
      });
    }
  }

}

