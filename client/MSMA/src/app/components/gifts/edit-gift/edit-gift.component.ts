import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GiftsService } from '../../../Service/gifts.service';
import { Gift } from '../../../Models/gift.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule, NgIf } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-edit-gift',
  imports: [CommonModule, FormsModule,ReactiveFormsModule,
  
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    ReactiveFormsModule, ],
  standalone: true,
  templateUrl: './edit-gift.component.html',
  styleUrl: './edit-gift.component.css'
})
export class EditGiftComponent {
  gift: Gift = new Gift()
  idGift: number = -1
  srvGift: GiftsService = inject(GiftsService)
  frmGift!: FormGroup
  selectedFile: File | null = null;
  image: string | ArrayBuffer | null = null;
  activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  router: Router = inject(Router);
  f:boolean=false
  giftListDB: Gift[] = []
  amount: number = 1
  
  constructor() 
  {
        this.srvGift.getAll().subscribe(
        gifts => {
          this.giftListDB = gifts; console.log(this.giftListDB);
          this.giftListDB.forEach(e=>
            {
              if(e.id==this.idGift)
              {
                this.gift=e
                this.image=e.img||""
              }
            })
            
          this.frmGift = new FormGroup({
            name: new FormControl(this.gift.name || ""),
            cost: new FormControl(this.gift.cost || 0),
            category: new FormControl(this.gift.category || 0),
            img: new FormControl(this.gift.img || ""),
            donorId: new FormControl(this.gift.donorId || 1)
        })
    
    }
      );
  }
  
  update() 
  {
    let g: Gift = new Gift()
        g.name = this.frmGift.controls['name'].value;
        g.cost = this.frmGift.controls['cost'].value;
        g.donorId = this.frmGift.controls['donorId'].value;
        g.img =this.frmGift.controls['img'].value;
        g.category = this.frmGift.controls['category'].value;
    if (g.cost != 0 && g.name != '' && g.donorId != 0) {
      this.srvGift.update(this.idGift, g).subscribe(date => { 
      
      if(this.f)
        this.srvGift.updateImage(this.selectedFile, this.idGift);
      });
      this.router.navigate(['gifts'])

    }
    else
      alert("חסר ערך")
  }


  ngOnInit() 
  {
      this.activatedRoute.params.subscribe(p => {
        if (p['id'] > 0) {
          this.idGift = p['id'];

        } 
      
      })
    


  }
  
  onFileSelected(event: Event): void {
    this.f=true
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

