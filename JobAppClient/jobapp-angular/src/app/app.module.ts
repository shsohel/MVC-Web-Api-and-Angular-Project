import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule, routes } from './app-routing.module';
import { ReactiveFormsModule  } from '@angular/forms';
import { AppComponent } from './app.component';
import { RootComponent } from './root/root.component';
import { HomeComponent } from './home/home.component';
import { JobComponent } from './job/job.component';
import { JobCreateComponent } from './job/job-create/job-create.component';
import { JobListComponent } from './job/job-list/job-list.component';
import { JoblistService } from './shared/job/joblist.service';
import { JobseekerRegistrationComponent } from './users/jobseeker-registration/jobseeker-registration.component';
import { JobseekerregistraionService } from './shared/jobseeker/jobseekerregistraion.service';
import { JsregisterFormComponent } from './users/jobseeker-registration/jsregister-form/jsregister-form.component';
import { JsloginFormComponent } from './users/jobseeker-registration/jslogin-form/jslogin-form.component';
import { UsersComponent } from './users/users.component';
import { NavigationComponent } from './navigation/navigation.component';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EmployeerdashboardComponent } from './dashboard/employeerdashboard/employeerdashboard.component';
import { JobseekerdashboardComponent } from './dashboard/jobseekerdashboard/jobseekerdashboard.component';
import { AdmindashboardComponent } from './dashboard/admindashboard/admindashboard.component';
import { JobseekerprofileComponent } from './jobseekerprofile/jobseekerprofile.component';
import { PersonalinfoComponent } from './jobseekerprofile/personalinfo/personalinfo.component';
import { AuthGuard } from './auth/auth.guard';
import { FooterComponent } from './navigation/footer/footer.component';
import { httpInterceptorProviders } from './auth/index';
import { UpdatepersonalinfoComponent } from './jobseekerprofile/updatepersonalinfo/updatepersonalinfo.component';
import { MainpagejobComponent } from './job/mainpagejob/mainpagejob.component';
import { EmployeerRegistrationComponent } from './users/employeer-registration/employeer-registration.component';
import { EmloginFormComponent } from './users/employeer-registration/emlogin-form/emlogin-form.component';
import { EmregisterFormComponent } from './users/employeer-registration/emregister-form/emregister-form.component';
import { NavpersonalinfoComponent } from './navigation/navpersonalinfo/navpersonalinfo.component';

import { EducationFormComponent } from './jobseekerprofile/educationinfo/education-form/education-form.component';
import { EducationListComponent } from './jobseekerprofile/educationinfo/education-list/education-list.component';
import { ExperienceListComponent } from './jobseekerprofile/experienceinfo/experience-list/experience-list.component';
import { ExperienceFormComponent } from './jobseekerprofile/experienceinfo/experience-form/experience-form.component';
import { SkillFormComponent } from './jobseekerprofile/skillinfo/skill-form/skill-form.component';
import { SkillListComponent } from './jobseekerprofile/skillinfo/skill-list/skill-list.component';
import { TrainingFormComponent } from './jobseekerprofile/traininginfo/training-form/training-form.component';
import { TrainingListComponent } from './jobseekerprofile/traininginfo/training-list/training-list.component';
import { JsaddressFormComponent } from './jobseekerprofile/jsaddress/jsaddress-form/jsaddress-form.component';
import { JsaddressListComponent } from './jobseekerprofile/jsaddress/jsaddress-list/jsaddress-list.component';
import { EmploeerinfoFormComponent } from './employeerprofile/employeerinfo/emploeerinfo-form/emploeerinfo-form.component';
import { EmploeerinfoListComponent } from './employeerprofile/employeerinfo/emploeerinfo-list/emploeerinfo-list.component';
import { CompanyaddressFormComponent } from './employeerprofile/companyaddress/companyaddress-form/companyaddress-form.component';
import { CompanyaddressListComponent } from './employeerprofile/companyaddress/companyaddress-list/companyaddress-list.component';
import { EmployeernavComponent } from './navigation/navemployeer/employeernav/employeernav.component';
import { JobpostformlistComponent } from './employeerprofile/jobpost/jobpostformlist/jobpostformlist.component';
import { JobapplyListComponent } from './jobapply/jobapply-list/jobapply-list.component';
import { JobapplyCandidatesComponent } from './jobapply/jobapply-candidates/jobapply-candidates.component';
import { JobapplyFormComponent } from './jobapply/jobapply-form/jobapply-form.component';





@NgModule({
  declarations: [
    AppComponent,
    RootComponent,
    HomeComponent,
    JobComponent,
    JobCreateComponent,
    JobListComponent,
    JobseekerRegistrationComponent,
    JsregisterFormComponent,
    JsloginFormComponent,
    UsersComponent,
    NavigationComponent,
    DashboardComponent,
    EmployeerdashboardComponent,
    JobseekerdashboardComponent,
    AdmindashboardComponent,
    JobseekerprofileComponent,
    PersonalinfoComponent,
    FooterComponent,
    UpdatepersonalinfoComponent,
    MainpagejobComponent,
    EmployeerRegistrationComponent,
    EmloginFormComponent,
    EmregisterFormComponent,
    NavpersonalinfoComponent,
    EducationFormComponent,
    EducationListComponent,
    ExperienceListComponent,
    ExperienceFormComponent,
    SkillFormComponent,
    SkillListComponent,
    TrainingFormComponent,
    TrainingListComponent,
    JsaddressFormComponent,
    JsaddressListComponent,
    EmploeerinfoFormComponent,
    EmploeerinfoListComponent,
    CompanyaddressFormComponent,
    CompanyaddressListComponent,
    EmployeernavComponent,
    JobapplyListComponent,
    JobpostformlistComponent,
 JobapplyFormComponent,
    JobapplyCandidatesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [JoblistService, JobseekerregistraionService, httpInterceptorProviders, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
