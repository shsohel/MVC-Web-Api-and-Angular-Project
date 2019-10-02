import { Injectable } from '@angular/core';
import { Jobapply } from './jobapply.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class JobapplyService {
  formData: Jobapply;
  list: Jobapply[];
  rootURl = localStorage.getItem('url');
  constructor(private http: HttpClient) { }

  postApplyJob(formData: Jobapply) {
    return this.http.post(this.rootURl + '/ApplyJob/ApplyJobInsert', formData);
   }


   refreshList() {
    this.http.get(this.rootURl + '/ApplyJob/GetApplicationList')
    .toPromise().then(res => this.list = res as Jobapply[]);
  }

  getApplyJob() {
    return this.http.get(this.rootURl + '/ApplyJob/GetApplicationList');
  }



  getjApplyJobid( id: number) {
    return this.http.get(this.rootURl + '/ApplyJob/GetApplicantListById/' + id);
  }

  putApplyJob(formData: Jobapply) {
    return this.http.put(this.rootURl + '/ApplyJob/ApplyJobUpdate/' + formData.ApplyJobID, formData);

   }


   deleteApplyJob(id: number) {
    return this.http.delete(this.rootURl + '/ApplyJob/CancelApplyJob/' + id);

   }

}
