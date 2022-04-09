import { Component } from '@angular/core';
import { User } from '../models/user';
import { UserService } from '../services/user.service';


// VIEW-MODEL
@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(private userService: UserService) {}


  public users: User[];


  loadUsers() {
    this.userService.getUsers()
      .subscribe(u => {
        this.users = u;
        console.info(u);
      });
  }
}
