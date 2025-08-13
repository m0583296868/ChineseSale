import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import {MatTabsModule} from '@angular/material/tabs';
import {MatButtonModule} from '@angular/material/button';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';



@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CommonModule,MatTabsModule, MatButtonModule,RouterLink,MatToolbarModule,MatMenuModule,MatIconModule],
  
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'MSMA';
  router: Router = inject(Router);
  links = ['First', 'Second', 'Third'];
  activeLink = this.links[0];
  f:boolean=false
  moveRegister(){
    this.router.navigate(['register']); 

  }
  moveLogin(){

    this.router.navigate(['login']); 

  }
  moveAddDonor(){
    this.router.navigate(['donors']); 

  }
  gifts(){
    this.router.navigate(['gifts']); 

  }
  home(){
    this.router.navigate(['']); 

  }
  signOut(){
    this.f=false

    localStorage.setItem("userId","0")
    localStorage.setItem("orderId","0")
    localStorage.setItem("token","0")
    localStorage.setItem("role","user")
alert("יצאת מהמערכת, בהצלחה")
      this.router.navigate(['']);
   
this.ngOnInit()
  }
  toCard(){
    this.router.navigate(['card']); 

  }
  
ngOnInit(){
  if(localStorage.getItem("role")=="Admin")
    this.f=true
}
}
