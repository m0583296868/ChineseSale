import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Users } from '../../../Models/user.model';
import { Router } from '@angular/router';
import { Donor } from '../../../Models/donor.model';
import { DonorsService } from '../../../Service/donors.service';
import { ListDonorsComponent } from '../list-donors/list-donors.component';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-add-donor',
  imports: [CommonModule, FormsModule,ReactiveFormsModule,MatIconModule,
  
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,],
  standalone: true,

  templateUrl: './add-donor.component.html',
  styleUrl: './add-donor.component.css'
})
export class AddDonorComponent {
  router: Router = inject(Router);
  srvDonor: DonorsService = inject(DonorsService)
  frmDonor!: FormGroup
  f:boolean=false

  constructor() {
    this.frmDonor = new FormGroup({
      name: new FormControl(''),
      mail: new FormControl(''),
      phone: new FormControl(''),
       })
  }

addDonor(){
  var d:Donor=new Donor()
  d.name = this.frmDonor.controls['name'].value;
  d.mail = this.frmDonor.controls['mail'].value;
  d.phone = this.frmDonor.controls['phone'].value;
  d.id=0
if(d.name!=''&&d.mail!=''){
  
this.srvDonor.add(d).subscribe()
    
this.router.navigate(['donors']);
}
else
 alert("חסר ערך")
}
cancel(){
  this.router.navigate(['donors']);

}
ngOnInit(){
  if(localStorage.getItem("role")=="Admin")
    this.f=true
}

}
