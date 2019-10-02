import { Injectable } from '@angular/core';
import { Companyaddress } from './companyaddress.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CompanyaddressdetailsService {
  formData: Companyaddress;
  list: Companyaddress[];
  rootURl = localStorage.getItem('url');
  constructor(private http: HttpClient) {

  }

   refreshList() {
    this.http.get(this.rootURl + '/CompanyAddress/GetCompanyAddress')
    .toPromise().then(res => this.list = res as Companyaddress[]);
  }

  postCompanyaddress(formData: Companyaddress) {
    return this.http.post(this.rootURl + '/CompanyAddress/InsertCompanyAddress', formData);
   }

  getCompanyaddress() {
    return this.http.get(this.rootURl + '/CompanyAddress/GetCompanyAddress');
  }

  getCompanyaddressID(id: number) {
    return this.http.get(this.rootURl + '/CompanyAddress/GetCompanyAddressById/' + id);
  }


  putCompanyaddress(formData: Companyaddress) {
    return this.http.put(this.rootURl + '/CompanyAddress/UpdateCompanyAddress/' + formData.EmployerID, formData);
   }

   deleteCompanyaddress(id: number) {
    return this.http.delete(this.rootURl + '/CompanyAddress/DeleteCompanyAddress/' + id);

   }

}
