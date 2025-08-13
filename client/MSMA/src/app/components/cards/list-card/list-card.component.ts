import { Component ,inject} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { Card } from '../../../Models/card.model';
import { CardsService } from '../../../Service/cards.service';

@Component({
  selector: 'app-list-card',
  imports: [CommonModule, FormsModule,RouterOutlet],
  standalone: true,

  templateUrl: './list-card.component.html',
  styleUrl: './list-card.component.css'
})
export class ListCardComponent {
  router: Router = inject(Router);

  srvCard:CardsService=inject(CardsService)
  // cardsListDB:Card[]=[]
  
  // cardsGifts = this.srvCard.getAll().subscribe(
  //   cards => {
  //  this.cardsListDB = cards;}
  // );
  


  }
  
