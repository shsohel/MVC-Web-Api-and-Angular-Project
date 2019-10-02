import { Injectable } from '@angular/core';

import { Employeerinfo } from './employeerinfo.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeerinfoService {
  formData: Employeerinfo;
  list: Employeerinfo[];
  rootURl = localStorage.getItem('url');
  constructor(private http: HttpClient) {

  }

   refreshList() {
    this.http.get(this.rootURl + '/Employer/GetEmployer')
    .toPromise().then(res => this.list = res as Employeerinfo[]);
  }

  postEmployer(formData: Employeerinfo) {
    return this.http.post(this.rootURl + '/Employer/InsertEmployer', formData);
   }

  getEmployeer() {
    return this.http.get(this.rootURl + '/Employer/GetEmployer');
  }

  getEmployeerID(id: number) {
    return this.http.get(this.rootURl + '/Employer/GetEmployerById/' + id);
  }


  putEmployeer(formData: Employeerinfo) {
    return this.http.put(this.rootURl + '/Employer/UpdateEmployer/' + formData.EmployerID, formData);
   }

   deleteEmployeer(id: number) {
    return this.http.delete(this.rootURl + '/Employer/DeleteEmployer/' + id);

   }

}
