import { Injectable } from '@angular/core';
import { Skill } from './skill.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SkilldetailsService {
  formData: Skill;
  list: Skill[];
  rootURl = localStorage.getItem('url');
  constructor(private http: HttpClient) {

  }

   refreshList() {
    this.http.get(this.rootURl + '/Skill/GetSkill')
    .toPromise().then(res => this.list = res as Skill[]);
  }

  postSkill(formData: Skill) {
    return this.http.post(this.rootURl + '/Skill/InsertSkill', formData);
   }

  getSkill() {
    return this.http.get(this.rootURl + '/Skill/GetSkill');
  }

  getSkillID(id: number) {
    return this.http.get(this.rootURl + '/Skill/GetSkillById/' + id);
  }


  putSkill(formData: Skill) {
    return this.http.put(this.rootURl + '/Skill/UpdateSkill/' + formData.SkillID, formData);
   }

   deleteSkill(id: number) {
    return this.http.delete(this.rootURl + '/Skill/DeleteSkill/' + id);

   }

}
