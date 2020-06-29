import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test-users',
  templateUrl: './test-users.component.html',
  styleUrls: ['./test-users.component.css']
})
export class TestUsersComponent implements OnInit {

  constructor(private http: HttpClient) { }
  users: any;

  ngOnInit() {
    this.getUsers();
  }

  getUsers(){
    this.http.get('http://localhost:5000/api/users').subscribe((data) => {
      this.users = data;
      console.log(data);
    });
  }

}
