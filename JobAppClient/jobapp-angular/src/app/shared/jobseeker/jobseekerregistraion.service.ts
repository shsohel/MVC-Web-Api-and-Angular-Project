import { Injectable } from '@angular/core';
import { Jobseeker } from './jobseeker.model';
import {HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from '@angular/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class JobseekerregistraionService {
  formData: Jobseeker;
  jobseeker: Jobseeker[];
  rootURl = localStorage.getItem('url');
 // readonly myTo = 'http://localhost:51654';

  constructor(private http: HttpClient, private router: Router) { }
  postJob(formData: Jobseeker) {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.post(this.rootURl + '/Account/Register', formData, {headers : reqHeader});
   }
   userAuthentication(userName, password) {
    const data = 'username=' + userName + '&password=' + password + '&grant_type=password';
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded', 'No-Auth': 'True' });
    return this.http.post(this.rootURl + '/token', data, { headers: reqHeader });
  }

  getUserClaims() {
    return  this.http.get(this.rootURl + '/api/Account/UserInfo',
    {headers: new HttpHeaders({'Authorization': 'Bearer' + localStorage.getItem('userToken')})});
   }

  }


