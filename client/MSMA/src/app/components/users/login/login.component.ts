import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from '../../../Service/users.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Token } from '@angular/compiler';
import { resUser } from '../../../Models/resUser.model';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon'; // ייבוא MatIcon (אם אתה משתמש באייקונים)
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // ייבוא של אנימציות
import { CardsService } from '../../../Service/cards.service';
import { Card } from '../../../Models/card.model';


@Component({
  selector: 'app-login',
  imports: [CommonModule, FormsModule,ReactiveFormsModule,MatIconModule,
  
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
  ],
 standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  
  router: Router = inject(Router);
  srvUser: UsersService = inject(UsersService)
thoken:string=''
myResUser:resUser=new resUser()
password:string=''
userName:string=''

srvCard:CardsService=inject(CardsService)
listMyCard:Card[]=[]

f:boolean=false

login(){


if(this.password!=''&&this.userName!='')
{



    this.srvUser.login(this.userName,this.password).subscribe(s=>{this.myResUser=s;console.log(this.myResUser);
      if(s==null)
        {
          alert("שם משתמש או סיסמא שגויים. אנא נסה שנית");
          return
        }


    localStorage.setItem("token",this.myResUser.token||"");
    localStorage.setItem("userId",this.myResUser.userId?.toString()||"");
    localStorage.setItem("role",this.myResUser.role||"") 
    this.ngOnInit()
    this.srvCard.getMyCard().subscribe(
      cards => {
        this.listMyCard = cards;
        if (this.listMyCard.length > 0)
            localStorage.setItem("orderId",this.listMyCard[0].orderId?.toString()||"0");
            alert("התחברת בהצלחה! ברוך שובך")})
            })
            this.router.navigate([''])
}

else
    alert("חסר ערך")
  
}


ngOnInit(){
  if(localStorage.getItem("role")=="Admin")
    this.f=true
}


}
