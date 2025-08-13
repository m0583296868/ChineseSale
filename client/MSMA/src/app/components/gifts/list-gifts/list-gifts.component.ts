import { ChangeDetectorRef, Component, inject } from '@angular/core';
import { GiftsService } from '../../../Service/gifts.service';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Category, Gift } from '../../../Models/gift.model';
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from '@angular/router';
import { CardsService } from '../../../Service/cards.service';
import { Card } from '../../../Models/card.model';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-list-gifts',
  imports: [CommonModule, FormsModule,ReactiveFormsModule, MatTabsModule, MatButtonModule,MatToolbarModule
    ,MatMenuModule,MatIconModule,MatInputModule,MatCardModule,MatFormFieldModule,MatButtonModule, MatDividerModule, MatIconModule,
     MatSelectModule,],
  
  standalone: true,
  templateUrl: './list-gifts.component.html',
  styleUrl: './list-gifts.component.css'
})
export class ListGiftsComponent {
  router: Router = inject(Router);
  srvCard: CardsService = inject(CardsService)
  srvGift: GiftsService = inject(GiftsService)
  giftListDB: Gift[] = []
  getersListDB: any[] = []
  isWasRandom: boolean = false
  isCanBuy: boolean = false
  theGeter: string = ''
  amount: number = 1
  searchByCategory:Category=0
  f:boolean=false

  listGifts = this.srvGift.getAll().subscribe(
    gifts => {
      this.giftListDB = gifts;console.log(this.giftListDB[0].cost)
    }

  );

  listGeters = this.srvGift.getAllGeters().subscribe(
    getter => {
      this.getersListDB = getter;
      console.log(this.getersListDB)
    })

  isW = this.srvGift.isWasR().subscribe(
    r => {
      this.isWasRandom = r;
    }
  )


  delete(id: number) {

    var res = this.srvGift.delete(id).subscribe(res => {
      this.srvGift.getAll().subscribe(
        gifts => {
          this.giftListDB = gifts;
        })
    })

  }
  
  update(id: number) {
    this.router.navigate(['gifts/' + id]);
  }

  add() {
    this.router.navigate(['gifts/addGift']);
  }
  addCard(giftId: number,amount:number) {    
    var c = new Card()
    c.amount = amount
    c.giftId = giftId
  
    if( (Number)(localStorage.getItem("orderId"))== 0)
      this.srvCard.newOrder().subscribe(i => {
      localStorage.setItem("orderId", i.toString())
      this.srvCard.add(c).subscribe(data => { this.isCanBuy = data ;
      if (!this.isCanBuy) alert("מתנה זו כבר הוגרלה. אין אפשרות לרכוש כרטיס זה")
      else
      alert("הכרטים נוסף לסל בהצלחה")})
   })
    else{
    this.srvCard.add(c).subscribe(data => { this.isCanBuy = data ;
      if (!this.isCanBuy) alert("מתנה זו כבר הוגרלה. אין אפשרות לרכוש כרטיס זה")
      else
        alert("הכרטים נוסף לסל בהצלחה")})
  }
  }

    random(id: number) {
      var res = this.srvGift.random(id).subscribe(
      getter => { this.theGeter = getter; }
    )

    alert("ההגרלה התבצעה")
  }

  getAllGeters() 
  {
      var res = this.srvGift.getAllGeters().subscribe(
      getter => { this.getersListDB = getter })
  }

  ngOnInit() {
   
      if(localStorage.getItem("role")=="Admin")
        this.f=true
    
      this.srvGift.getAll().subscribe(
           gifts => {
           this.giftListDB = gifts;
      })

   
  }

  
selectByCategory(){
  this.srvGift.selectByCategory(this.searchByCategory).subscribe(
    gifts => {
      this.giftListDB = gifts;
    }
  )
}
clear(){
  this.srvGift.getAll().subscribe(
    gifts => {
         this.giftListDB = gifts;
    })
}
ngOnChanges(){
  

  if(this.searchByCategory !=0){
    this.selectByCategory()

  }

  
}
}