import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';

import { User } from '../models/user';
import { UserAccount } from '../models/userAccount';

@Component({
  selector: 'app-user-details-component',
  templateUrl: './user-details.component.html'
})
export class UserDetailsComponent implements OnInit {
  public accountForm: FormGroup = new FormGroup({
    initialCredit: new FormControl(),
  });
  public user: User | null = null;
  public userId: string = '';
  public baseUrl: string;
  public http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.userId = this.route.snapshot.params['userId'];
    this.http.get<User[]>(this.baseUrl + `users/${this.userId}`).subscribe((result: any) => {
      this.user = result.user;
    })
  }

  onSubmit(form: FormGroup) {
    if (form.valid) {
      const { initialCredit } = form.value;
      this.http.post<UserAccount>(this.baseUrl + `users/${this.userId}/accounts`, {
        initialCredit: {
          value: initialCredit,
          currency: 'EUR'
        }
      }).subscribe((result: any) => {
        console.log(result);
      }, (error: any) => console.error(error));
    }
  }
}

