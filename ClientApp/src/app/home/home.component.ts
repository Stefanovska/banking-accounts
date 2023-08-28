import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { Subject } from 'rxjs';

import { User } from '../models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public users: User[] = [];
  public userForm: FormGroup = new FormGroup({
    name: new FormControl(''),
    surname: new FormControl(''),
  });
  public baseUrl: string;
  public http: HttpClient;
  private subject$ = new Subject<User>();

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    http.get<User[]>(baseUrl + 'users').subscribe((result: any) => {
      this.users = result.users;
    })
    this.subject$.subscribe(user => {
      this.users.push(user);
    })
  }

  onSubmit(form: FormGroup) {
    if (form.valid) {
      this.http.post<User[]>(this.baseUrl + 'users', form.value).subscribe((result: any) => {
        this.subject$.next(result.user);
      }, (error: any) => console.error(error));
    }
  }
}

