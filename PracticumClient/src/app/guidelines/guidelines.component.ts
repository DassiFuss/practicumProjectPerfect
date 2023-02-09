import { Component, OnDestroy, OnInit } from '@angular/core';
import User from 'src/models/User';
import {Subscription} from 'rxjs'
import { UserService } from '../user.service';
@Component({
  selector: 'app-guidelines',
  templateUrl: './guidelines.component.html',
  styleUrls: ['./guidelines.component.scss']
})
export class GuidelinesComponent implements OnInit, OnDestroy {
 userName=null;
 sub:Subscription;
  constructor(public userService:UserService) { }
 ngOnDestroy(): void {
  this.sub.unsubscribe();
   
 }
  ngOnInit(): void {
    this.sub=this.userService.currentUser.subscribe(succ=>{
      this.userName=succ?.name;
      console.log("from subscribe");
    })
  }
  logOut(){
    this.userService.removeCurrentUserFromStorage();
    this.userService.currentUser.next(null);
  }
}
