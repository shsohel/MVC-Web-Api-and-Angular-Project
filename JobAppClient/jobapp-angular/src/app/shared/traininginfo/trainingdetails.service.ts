import { Injectable } from '@angular/core';
import { Training } from './training.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TrainingdetailsService {
  formData: Training;
  list: Training[];
  rootURl = localStorage.getItem('url');
  constructor(private http: HttpClient) {

  }

   refreshList() {
    this.http.get(this.rootURl + '/Training/GetTraining')
    .toPromise().then(res => this.list = res as Training[]);
  }

  postTraining(formData: Training) {
    return this.http.post(this.rootURl + '/Training/InsertTraining', formData);
   }

  getTraining() {
    return this.http.get(this.rootURl + '/Training/GetTraining');
  }

  getTrainingID(id: number) {
    return this.http.get(this.rootURl + '/Training/GetTrainingById/' + id);
  }


  putTraining(formData: Training) {
    return this.http.put(this.rootURl + '/Training/UpdateTraining/' + formData.TrainingID, formData);
   }

   deleteTraining(id: number) {
    return this.http.delete(this.rootURl + '/Training/DeleteTraining/' + id);

   }

}
