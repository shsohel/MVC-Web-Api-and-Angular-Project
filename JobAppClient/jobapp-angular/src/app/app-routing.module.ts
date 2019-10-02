import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {RootComponent} from './root/root.component';
import {HomeComponent} from './home/home.component';
import { UsersComponent } from './users/users.component';
import { JobseekerRegistrationComponent } from './users/jobseeker-registration/jobseeker-registration.component';
import { JsloginFormComponent } from './users/jobseeker-registration/jslogin-form/jslogin-form.component';
import { JsregisterFormComponent } from './users/jobseeker-registration/jsregister-form/jsregister-form.component';
import { NavigationComponent } from './navigation/navigation.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { JobseekerdashboardComponent } from './dashboard/jobseekerdashboard/jobseekerdashboard.component';
import { EmployeerdashboardComponent } from './dashboard/employeerdashboard/employeerdashboard.component';
import { JobseekerprofileComponent } from './jobseekerprofile/jobseekerprofile.component';
import { AuthGuard } from './auth/auth.guard';
import { JobListComponent } from './job/job-list/job-list.component';
import { MainpagejobComponent } from './job/mainpagejob/mainpagejob.component';
import { EmployeerRegistrationComponent } from './users/employeer-registration/employeer-registration.component';
import { EmloginFormComponent } from './users/employeer-registration/emlogin-form/emlogin-form.component';
import { EmregisterFormComponent } from './users/employeer-registration/emregister-form/emregister-form.component';
import { PersonalinfoComponent } from './jobseekerprofile/personalinfo/personalinfo.component';
import { UpdatepersonalinfoComponent } from './jobseekerprofile/updatepersonalinfo/updatepersonalinfo.component';
import { Education } from './shared/educationinfo/education.model';
import { EducationListComponent } from './jobseekerprofile/educationinfo/education-list/education-list.component';
import { EducationFormComponent } from './jobseekerprofile/educationinfo/education-form/education-form.component';
import { ExperienceListComponent } from './jobseekerprofile/experienceinfo/experience-list/experience-list.component';
import { ExperienceFormComponent } from './jobseekerprofile/experienceinfo/experience-form/experience-form.component';
import { SkillListComponent } from './jobseekerprofile/skillinfo/skill-list/skill-list.component';
import { SkillFormComponent } from './jobseekerprofile/skillinfo/skill-form/skill-form.component';
import { TrainingListComponent } from './jobseekerprofile/traininginfo/training-list/training-list.component';
import { TrainingFormComponent } from './jobseekerprofile/traininginfo/training-form/training-form.component';
import { JsaddressListComponent } from './jobseekerprofile/jsaddress/jsaddress-list/jsaddress-list.component';
import { JsaddressFormComponent } from './jobseekerprofile/jsaddress/jsaddress-form/jsaddress-form.component';
import { EmploeerinfoListComponent } from './employeerprofile/employeerinfo/emploeerinfo-list/emploeerinfo-list.component';
import { EmploeerinfoFormComponent } from './employeerprofile/employeerinfo/emploeerinfo-form/emploeerinfo-form.component';
import { CompanyaddressListComponent } from './employeerprofile/companyaddress/companyaddress-list/companyaddress-list.component';
import { CompanyaddressFormComponent } from './employeerprofile/companyaddress/companyaddress-form/companyaddress-form.component';
import { JobpostformlistComponent } from './employeerprofile/jobpost/jobpostformlist/jobpostformlist.component';
import { JobapplyListComponent } from './jobapply/jobapply-list/jobapply-list.component';
import { JobapplyFormComponent } from './jobapply/jobapply-form/jobapply-form.component';




export const routes: Routes = [
  {
    path: 'home', component: HomeComponent
  },
  {
    path: 'users', component: UsersComponent,
    children: [
      { path: '', component: NavigationComponent }
    ]
  },


  {
    path: 'jsregister', component: JobseekerRegistrationComponent,
    children: [
      { path: 'login', component: JsloginFormComponent},
      { path: 'signup', component: JsregisterFormComponent }
    ]

  },


  {
    path: 'emplregister', component: EmployeerRegistrationComponent,
    children: [
      { path: 'login', component: EmloginFormComponent},
      { path: 'signup', component: EmregisterFormComponent }
    ]

  },

{
  path: 'dashboard', component: DashboardComponent,

children: [
  {path: 'jobseekerdashboard', component: JobseekerdashboardComponent,

children: [

  {path: 'pinfo', component: PersonalinfoComponent,
  children: [
    {path : '', component: UpdatepersonalinfoComponent}]
  },

  {path: 'eduinfo', component: EducationListComponent,
children: [
  {path: '', component: EducationFormComponent}]
  },
  {path: 'expInfo', component: ExperienceListComponent,
  children: [
    {path: '', component: ExperienceFormComponent}]
  },
  {path: 'skiliInfo', component: SkillListComponent,
  children: [
    {path: '', component: SkillFormComponent}]
  },

  {path: 'trainingInfo', component: TrainingListComponent,
    children: [
      {path: '', component: TrainingFormComponent}]
    },
    {path: 'jsaddinfo', component: JsaddressListComponent,
    children: [
      {path: '', component: JsaddressFormComponent}]
    },

  {path: 'jobappplyu', component: JobapplyListComponent,
  children: [
    {path: '', component: JobapplyFormComponent}]
  }
]}], canActivate: [AuthGuard]},


/*
, canActivate: [AuthGuard]

*/
{
path: 'dashboard', component: DashboardComponent,
children: [
  {path: 'employeer', component: EmployeerdashboardComponent,
children: [
{path: 'emplInf', component: EmploeerinfoListComponent,
children: [
  {path: '', component: EmploeerinfoFormComponent}
]},

{path: 'emplAddr', component: CompanyaddressListComponent,
children: [
  {path: '', component: CompanyaddressFormComponent}
]},

{path: 'jobpost', component: JobpostformlistComponent}


]}], canActivate: [AuthGuard]},


  { path: 'root', component: RootComponent },
  { path: '', redirectTo: '/root', pathMatch: 'full' }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
