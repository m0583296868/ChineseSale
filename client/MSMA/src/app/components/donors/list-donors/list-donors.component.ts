import { Component, inject } from '@angular/core';
import { Donor } from '../../../Models/donor.model';
import { Router } from '@angular/router';
import { DonorsService } from '../../../Service/donors.service';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-list-donors',
  imports: [MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    ReactiveFormsModule,MatIconModule],
  standalone: true,

  templateUrl: './list-donors.component.html',
  styleUrl: './list-donors.component.css'
})
export class ListDonorsComponent {
 donorListDB:Donor[]=[]
  router: Router = inject(Router);
  f:boolean=false
  srvDonor:DonorsService=inject(DonorsService)
  listGifts = this.srvDonor.getAll().subscribe(
    donor => {
   this.donorListDB = donor;}
  );
  AddDonor(){
    this.router.navigate(['donors/add']); 

  }
  ngOnInit(){
    if(localStorage.getItem("role")=="Admin")
      this.f=true
  }
  
}
