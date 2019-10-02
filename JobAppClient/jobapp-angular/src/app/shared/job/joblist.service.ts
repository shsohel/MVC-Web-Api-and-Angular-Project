import { Injectable } from '@angular/core';
import { Joblist } from './joblist.model';

import {HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';



@Injectable({
  providedIn: 'root'
})
export class JoblistService {
  formData: Joblist;
  list: Joblist[];
  rootURl = localStorage.getItem('url');
  constructor(private http: HttpClient) { }

  postJob(formData: Joblist) {
    return this.http.post(this.rootURl + '/JobList/InsertJobList', formData);
   }


   refreshList() {
    this.http.get(this.rootURl + '/JobList/GetJobList')
    .toPromise().then(res => this.list = res as Joblist[]);
  }

  getjoblist() {
    return this.http.get(this.rootURl + '/JobList/GetJobList');
  }


  putJoblist(formData: Joblist) {
    return this.http.put(this.rootURl + '/JobList/UpdateJobList/' + formData.JobListID, formData);

   }


   deleteJoblist(id: number) {
    return this.http.delete(this.rootURl + '/JobList/DeleteJobList/' + id);

   }

}
