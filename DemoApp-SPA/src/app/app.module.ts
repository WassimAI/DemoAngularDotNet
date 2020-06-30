import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { TestUsersComponent } from './test-users/test-users.component';
import { AuthService } from './_services/auth.service';
import {UsersService} from './_services/users.service';
import { NavComponent } from './nav/nav.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { appRoutes } from './route';

@NgModule({
   declarations: [
      AppComponent,
      TestUsersComponent,
      NavComponent,
      RegisterComponent,
      HomeComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService, UsersService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
