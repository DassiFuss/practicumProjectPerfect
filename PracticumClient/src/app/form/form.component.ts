import { Component,OnDestroy, OnInit } from '@angular/core';
import User from 'src/models/User';
import { NgForm } from '@angular/forms';
import { UserService } from '../user.service';
import * as XLSX from 'xlsx';
@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit{
  public user:User;
  public child:User;
  public isHusband:boolean=false;
  public isSex:boolean=false;
  public isStatus:boolean=false;
  showChild:boolean;
  userName={name:""};
  public countChildren:number;
  title = 'angular-app';
  fileName= 'ExcelSheet.xlsx';
  userList:User[]=[];
  checked=false;
  tableXl=false;
  disableSubmit=false;
  radioChild:string;
  constructor(public userService:UserService) { }
  ngOnInit(): void {
    this.user=this.userService.user; 
    this.child=this.userService.child;
    this.showChild=this.userService.showChild;
    this.isHusband=this.userService.isHusband;
    }
    AddChildren(){
      if(this.user.idFamily&&this.user.firstName&&this.user.lastName&&this.user.HMO&&this.user.birthDate)
      this.disableSubmit=true;
      if(this.user.idFamily!=null&&this.user.lastName!=null){
        this.userService.showChild=true;
      this.showChild=true;      
      }
      else alert("Complete all your details");
    }
    AddChild(){
      if(this.child.id!=null&&this.child.birthDate!=null&&this.child.firstName!=null){

      this.child.idFamily=this.userService.user.id;
      this.child.lastName=this.userService.user.lastName;
      console.log(this.child);
    this.userService.addChild(this.child).subscribe((succ)=>{console.log("childAdd")},(err)=>{
      console.log(err);
    })
    this.userList.push(this.child);
    console.log(this.userList);
      this.userService.child=new User(null,null,null,null,null,null,null,3);
  this.child=new User(null,null,null,null,null,null,null,3);
  this.userService.showChild=false;
  this.showChild=false;  }
else alert("Complete all your child details");
    }
exportData(){
    this.userList.push(this.user);
}
  exportexcel(): void
  {
    /* pass here the table id */
    let element = document.getElementById('excel-table');
    const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(element);
    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    /* save to file */  
    XLSX.writeFile(wb, this.fileName);
  }
changeName(){
  if(this.user.firstName&&this.user.lastName)
this.userName={name:this.user.firstName+" "+this.user.lastName};
else if(this.user.firstName)
this.userName={name:this.user.firstName};
else this.userName={name:this.user.lastName};
this.userService.saveCurrentUserInStorage(this.userName);
this.userService.currentUser.next(this.userName);
  console.log(this.userService.currentUser);
}
changedStatus(){
  if(this.user.status==1)
  this.isStatus=true; 
  else {
    this.isStatus=false;
    this.isHusband=false;
  this.userService.isHusband=false;}
   if(this.isSex&&this.isStatus){
    this.isHusband=true;
    this.userService.isHusband=true;
   }
 else{
  this.user.idFamily=this.user.id;}
}
changeSex(){
  if(this.user.sex==2)
  this.isSex=true;
  else {
    this.isSex=false;
    this.isHusband=false;
    this.userService.isHusband=false;
  }
  if(this.isStatus&&this.isSex){  
    this.isHusband=true;
    this.userService.isHusband=true;
  }
  else{
  this.user.idFamily=this.user.id;}
}
changeId(){
  this.userService.getUserById(this.userService.user.id).subscribe(succ=>{
    if(succ!=null) alert("This is a registered user"); console.log("changeId");
  },err=>console.log(err))
}
  submitForm(NgForm){
    this.userList.push(this.user);
    if(this.checked==true)
    this.exportexcel();
    this.userService.addUser(this.user).subscribe(succ=>{console.log("UserAdd")},err=>console.log(err));
    this.showChild=false;
this.userService.user=new User(null,null,null,null,new Date(),null,null,null);
this.user=this.userService.user;
    this.userService.removeCurrentUserFromStorage();
this.userService.currentUser.next(null);
this.isHusband=false;
this.userService.isHusband=false;
this.userList=[];
this.checked=false;
}
}