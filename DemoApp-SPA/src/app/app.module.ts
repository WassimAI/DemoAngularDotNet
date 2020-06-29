import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { TestUsersComponent } from './test-users/test-users.component';
import { AuthService } from './_services/auth.service';
import { NavComponent } from './nav/nav.component';

@NgModule({
   declarations: [
      AppComponent,
      TestUsersComponent,
      NavComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
