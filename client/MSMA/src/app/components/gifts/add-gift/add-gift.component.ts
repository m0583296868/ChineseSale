import { Component, inject } from '@angular/core';
import { GiftsService } from '../../../Service/gifts.service';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Gift } from '../../../Models/gift.model';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-add-gift',
  imports: [CommonModule, FormsModule,ReactiveFormsModule,
  MatIconModule,
  MatCardModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatButtonModule,
  ReactiveFormsModule,  // לוודא שמייבאים גם את ReactiveFormsModule
],

  standalone: true,
  templateUrl: './add-gift.component.html',
  styleUrl: './add-gift.component.css'
})

export class AddGiftComponent {
  srvGift:GiftsService=inject(GiftsService)
  selectedFile: File | null = null;
  image: string | ArrayBuffer | null = null;
  frmGift!: FormGroup
  router: Router = inject(Router);

  constructor() {
    this.frmGift = new FormGroup({
        name: new FormControl(''),
        cost: new FormControl(0),
        category: new FormControl(0) ,
        img: new FormControl('') ,
        donorId: new FormControl(0) 

    })
  }


  add() {
    let g: Gift = new Gift()
    g.name = this.frmGift.controls['name'].value;
    g.cost = this.frmGift.controls['cost'].value;
    g.donorId = this.frmGift.controls['donorId'].value;;
    g.category = this.frmGift.controls['category'].value;
    g.img= this.frmGift.controls['img'].value;

    if(g.cost!=0&&g.name!=''&&g.donorId!=0)
    {
      this.srvGift.add(g).subscribe(
        g=>{
      this.srvGift.updateImage(this.selectedFile, g.id);
          }
        );
        this.router.navigate(['gifts'])}
        else
        alert("חסר ערך")
      }


onFileSelected(event: Event): void 
{
        const input = event.target as HTMLInputElement;
        if (input.files && input.files.length > 0) {
            this.selectedFile = input.files[0];
            const reader = new FileReader();
            reader.onload = () => {
                this.image = reader.result; // שומר את התמונה במשתנה
            };
            reader.readAsDataURL(this.selectedFile);
    }
}

cancel(){
  this.router.navigate(['gifts']);

}


}

