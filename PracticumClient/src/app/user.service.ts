import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import User from 'src/models/User';
import {BehaviorSubject} from 'rxjs'
@Injectable({
  providedIn: 'root'
})
export class UserService {
currentUser=new BehaviorSubject<{name:string}>(null);
public user:User=new User(null,null,null,null,new Date(),null,null,null);
public child:User=new User(null,null,null,null,null,null,null,3);
public children: User[] = [];
showChild:boolean=false;
isHusband:boolean=false;
public baseRouteUrl=`${environment.baseUrl}/User`;
// detailsUser=new BehaviorSubject(User);
  constructor(public http:HttpClient) { }
  saveCurrentUserInStorage(user){
    localStorage.setItem("currentUser", JSON.stringify(user));
  }

  getCurrentUserFromStorage(user){
let u=localStorage.getItem("currentUser");
  if(!u)
     return null;
  return JSON.parse(u);
  }

removeCurrentUserFromStorage(){
   localStorage.removeItem("currentUser");
}

  addUser(user:User){
    console.log(user);
    // console.log(`${this.baseRouteUrl}/Post/?u=${user}`)
    return this.http.post<User>(`${this.baseRouteUrl}`,user);
  }
  addChild(user:User){
    console.log(user);
    // console.log(`${this.baseRouteUrl}/Post/?u=${user}`)
    return this.http.post<User>(`${this.baseRouteUrl}`,user);
  }
  getAllUsers(){
return this.http.get<User[]>(`${this.baseRouteUrl}`);
  }
  getUserById(id:string){
    return this.http.get<User>(`${this.baseRouteUrl}/${id}`);
  }
}
