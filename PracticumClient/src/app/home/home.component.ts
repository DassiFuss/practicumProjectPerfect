import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(public nav:Router) { }
Fill(){
this.nav.navigate(["form"]);
}
Instructions(){
  this.nav.navigate(["guidelines"]);
}
Home(){
  this.nav.navigate(["home"]);
}
  ngOnInit(): void {
  }

}
