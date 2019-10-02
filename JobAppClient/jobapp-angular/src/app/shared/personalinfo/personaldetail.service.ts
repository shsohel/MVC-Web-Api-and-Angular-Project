import { Injectable } from '@angular/core';
import { Personaldetail } from './personaldetail.model';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PersonaldetailService {
  formData: Personaldetail;
  list: Personaldetail[];
  rootURl = localStorage.getItem('url');
  constructor(private http: HttpClient) {

  }

   refreshList() {
    this.http.get(this.rootURl + '/PersonalDetail/GetPersonalDetailList')
    .toPromise().then(res => this.list = res as Personaldetail[]);
  }

  postDetails(formData: Personaldetail) {
    return this.http.post(this.rootURl + '/PersonalDetail/PersonalDetailInsert', formData);
   }

  getDetails() {
    return this.http.get(this.rootURl + '/PersonalDetail/GetPersonalDetailList');
  }

  putDetails(formData: Personaldetail) {
    return this.http.put(this.rootURl + '/PersonalDetail/PersonalUpdate/' + formData.PersonalDetailID, formData);
   }

   deleteDetails(id: number) {
    return this.http.delete(this.rootURl + '/PersonalDetail/CancelPersonalDetail/' + id);

   }

}
