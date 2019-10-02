import { Injectable } from '@angular/core';
import { Experience } from './experience.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExperiencedetailsService {
  formData: Experience;
  list: Experience[];
  rootURl = localStorage.getItem('url');
  constructor(private http: HttpClient) {

  }

   refreshList() {
    this.http.get(this.rootURl + '/Experience/GetExperience')
    .toPromise().then(res => this.list = res as Experience[]);
  }

  postExperience(formData: Experience) {
    return this.http.post(this.rootURl + '/Experience/InsertExperienceList', formData);
   }

  getExperience() {
    return this.http.get(this.rootURl + '/Experience/GetExperience');
  }

  getExperienceID(id: number) {
    return this.http.get(this.rootURl + '/Experience/GetExperienceById/' + id);
  }


  putExperience(formData: Experience) {
    return this.http.put(this.rootURl + '/Experience/UpdateExperience/' + formData.ExperienceID, formData);
   }

   deleteExperience(id: number) {
    return this.http.delete(this.rootURl + '/Experience/DeleteJobList/' + id);

   }

}
