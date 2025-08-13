import { Component, inject } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { Router } from '@angular/router';
import { GiftsService } from '../../Service/gifts.service';
import { Gift } from '../../Models/gift.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-msma',
  imports: [MatIconModule,MatButtonModule, MatDividerModule, MatIconModule,CommonModule,MatIconModule],
  standalone: true,

  templateUrl: './msma.component.html',
  styleUrl: './msma.component.css'
})
export class MsmaComponent {
  router: Router= inject(Router);
  srvGift: GiftsService = inject(GiftsService)
  giftListDB: Gift[] = []
  listGifts = this.srvGift.getAll().subscribe(
  gifts => {
       this.giftListDB = gifts;console.log(this.giftListDB[0].cost)
    }

  );

  enter(){
   
  this.router.navigate(['gifts']);
}
 
  }