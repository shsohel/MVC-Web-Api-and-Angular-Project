import { Injectable } from '@angular/core';
import { Education } from './education.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EducationdetailsService {
  formData: Education;
  list: Education[];
  rootURl = localStorage.getItem('url');
  constructor(private http: HttpClient) {

  }

   refreshList() {
    this.http.get(this.rootURl + '/Education/GetEducation')
    .toPromise().then(res => this.list = res as Education[]);
  }

  postEducation(formData: Education) {
    return this.http.post(this.rootURl + '/Education/InsertEducation', formData);
   }

  getEducation() {
    return this.http.get(this.rootURl + '/Education/GetEducation');
  }

  getEducationID(id: number) {
    return this.http.get(this.rootURl + '/Education/GetEducationtById/' + id);
  }


  putEducations(formData: Education) {
    return this.http.put(this.rootURl + '/Education/UpdateEducation/' + formData.EducationID, formData);
   }

   deleteEducation(id: number) {
    return this.http.delete(this.rootURl + '/Education/DeleteEducation/' + id);

   }

}
