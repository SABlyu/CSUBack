import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import { Observable, Subject } from 'rxjs';

@Injectable({providedIn: 'root'})
export class UserService {
  constructor(private httpClient: HttpClient) { }
  

  public getUsers(): Observable<User[]> {
    var url = 'https://localhost:7165/api/user';
    var result = new Subject<User[]>();

    this.httpClient.get<User[]>(url)
      .subscribe(
        u => result.next(u),
        e => console.error(e)
      );

    return result.asObservable();
  }
}