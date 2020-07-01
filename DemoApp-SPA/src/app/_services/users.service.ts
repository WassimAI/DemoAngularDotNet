import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

constructor(private http: HttpClient) { }

baseUrl: 'http://localhost:5000/api/users';

getUsers(): Observable<User[]>{
  return this.http.get<User[]>(this.baseUrl);
}

}
