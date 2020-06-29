import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from '../_services/alertify.service';
import {AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(private auth: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login(){
    this.auth.login(this.model).subscribe(next => {
      this.alertify.success('Login Successful!');
    }, error => {
      this.alertify.error('Sorry you are not authorized');
    });
  }



}
