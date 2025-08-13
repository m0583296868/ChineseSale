import { Component, inject } from '@angular/core';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { Card } from '../../../Models/card.model';
import { CardsService } from '../../../Service/cards.service';
import { Gift } from '../../../Models/gift.model';
import { GiftsService } from '../../../Service/gifts.service';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';


@Component({
  selector: 'app-list-orders',
  imports: [CommonModule, FormsModule, MatIconModule, MatCardModule, MatFormFieldModule, MatButtonModule, MatDividerModule, MatIconModule,
    MatSelectModule, ReactiveFormsModule, MatTabsModule, MatButtonModule, MatToolbarModule
    , MatMenuModule, MatIconModule, MatInputModule, MatCardModule, MatFormFieldModule, MatButtonModule, MatDividerModule, MatIconModule,
    MatSelectModule,],
  standalone: true,
  templateUrl: './list-orders.component.html',
  styleUrl: './list-orders.component.css'
})
export class ListOrdersComponent {
  router: Router = inject(Router);
  srvGift: GiftsService = inject(GiftsService)
  srvCard: CardsService = inject(CardsService)
  cardsListDB: Card[] = []
  giftsCards: Gift[] = []
  listMyCard: Card[] = []
  listGift: Gift[] = []
  f: boolean = false
  benefits: number = 0
  FinalPrice: number = 0


  cardsList = this.srvCard.getAll().subscribe(
    cards => {
      this.cardsListDB = cards;
      this.cardsListDB.forEach(element => {
        this.srvGift.getById(element.giftId).subscribe(
          data => {


            this.giftsCards.push(data);
          }
        )
      })

    })

  orderList = this.srvCard.getMyCard().subscribe(
    cards => {
      this.listMyCard = cards;
      if (this.listMyCard.length > 0)
        this.listMyCard.forEach(element => {
          this.srvGift.getById(element.giftId).subscribe(
            data => {
              data.cost *= element.amount || 1

              this.listGift.push(data);
              this.FinalPrice += data.cost || 0
            }

          )
        }); console.log(this.listGift)
    })

    getBenefits=this.srvCard.getBenefits().subscribe(data=>{
      this.benefits=data
    })
  /////

  ok() {
    this.srvCard.ok().subscribe(data => {
      localStorage.setItem("orderId", "0")
      alert("רכישה בוצעה בהצלחה")
      this.srvCard.getMyCard().subscribe(
        cards => {
          this.listMyCard = cards;
          this.FinalPrice = 0
        })
    })
  }

  delete(id: number) {

    var res = this.srvCard.delete(id).subscribe(res => {
      this.srvCard.getAll().subscribe(
        cards => {
          this.cardsListDB = cards;
        })
    })
  }

  ngOnInit() {
    if (localStorage.getItem("userId") == "0") {
      alert("אינך מחובר למערכת. התחבר ואז היכנס לסלך")
      this.router.navigate([''])
    }

    if (localStorage.getItem("role") == "Admin")
      this.f = true

    this.srvCard.getMyCard().subscribe(
      cards => {
        this.listMyCard = cards;

      })
  }

}

