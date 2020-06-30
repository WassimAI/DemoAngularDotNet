import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {UsersService} from '../_services/users.service';

@Component({
  selector: 'app-test-users',
  templateUrl: './test-users.component.html',
  styleUrls: ['./test-users.component.css']
})
export class TestUsersComponent implements OnInit {

  constructor(private usersService: UsersService) { }
  users: any;

  ngOnInit() {
  }

}
