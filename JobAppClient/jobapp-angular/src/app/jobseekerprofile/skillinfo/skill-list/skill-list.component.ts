import { Component, OnInit } from '@angular/core';
import { SkilldetailsService } from 'src/app/shared/skillinfo/skilldetails.service';
import { Skill } from 'src/app/shared/skillinfo/skill.model';

@Component({
  selector: 'app-skill-list',
  templateUrl: './skill-list.component.html',
  styleUrls: ['./skill-list.component.css']
})
export class SkillListComponent implements OnInit {
  rootURl = localStorage.getItem('url');
  constructor(private service: SkilldetailsService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(details: Skill) {
    this.service.formData = Object.assign({}, details);
  }

  onDelete(id: any) {
    if (confirm('Are You Sure??')) {
      console.log(id);
      this.service.deleteSkill(id).subscribe(x => {
        console.log(x), this.service.refreshList();
      });
    }
  }

}

