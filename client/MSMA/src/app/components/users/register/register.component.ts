import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsersService } from '../../../Service/users.service';
import { Users } from '../../../Models/user.model';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-register',
  imports: [CommonModule, FormsModule,ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    ReactiveFormsModule,],
  standalone: true,
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  router: Router = inject(Router);
  srvUser: UsersService = inject(UsersService)
  frmUser!: FormGroup

  constructor() {
    this.frmUser = new FormGroup({
      name: new FormControl(''),
      mail: new FormControl(''),
      phone: new FormControl(''),
      userName: new FormControl(''),
      password: new FormControl('')
    })
  }

  register() {
  
    
    var u: Users = new Users()
    u.name = this.frmUser.controls['name'].value;
    u.mail = this.frmUser.controls['mail'].value;
    u.phone = this.frmUser.controls['phone'].value;
    u.password = this.frmUser.controls['password'].value;
    u.userName = this.frmUser.controls['userName'].value;
    u.role=""
    u.id=0
     if(u.name!=''&&u.password!=''&&u.userName!='')
     {
        this.srvUser.add(u).subscribe();
        alert("נרשמת בהצלחה! שמחים שהתחברת אלינו:)")
        this.router.navigate(['login']);
     }
     
     else
      alert("חסר ערך")
  }

  cancel(){
    this.router.navigate(['']);
  
  }
}
