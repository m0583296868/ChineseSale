import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Card } from '../Models/card.model';
import { Order } from '../Models/order.model';

@Injectable({
  providedIn: 'root'
})
export class CardsService {
  userId: number = 0
  listMyCard: Card[] = []
  token = localStorage.getItem("token") || ""
  orderId = 0
  headers = new HttpHeaders().set('Authorization', `Bearer ${this.token}`);
  BASE_URL = 'http://localhost:5000/api/Card';
  ///http://localhost:5000/api/Order?value=1
  http: HttpClient = inject(HttpClient);
  add(item: Card): Observable<boolean> {
    if (this.userId == 0) { alert("אינך מחובר למערכת. היכנס כמשתמש ואז תוכל לרכוש") }
    this.ngOnInit()

    // if (this.orderId != 0)
    //   item.orderId = this.orderId
    // else {
    //   this.newOrder().subscribe(i => {
    //     debugger
    //     localStorage.setItem("orderId", i.toString())
    //   })
             
     
    // }
    // this.orderId = (Number)(localStorage.getItem("orderId")) || 0

    item.userId = this.userId
    item.orderId = this.orderId
    console.log(item)
    return this.http.post<boolean>(this.BASE_URL, item);

  }
  getAll(): Observable<Card[]> {

    return this.http.get<Card[]>(this.BASE_URL);
  }

  newOrder(): Observable<number> {
    return this.http.post<number>('http://localhost:5000/api/Order?value=' + this.userId, this.userId)
  } 
  getMyCard(): Observable<Card[]> {
    this.userId = (Number)(localStorage.getItem("userId")) || 0

    return this.http.get<Card[]>(this.BASE_URL + "/myCard/" + this.userId);
  }
  delete(id: number){

    var r = this.http.delete(this.BASE_URL + '/' + id);
    alert("נמחק  בהצלחה")
    return r
  }


  ok(): Observable<Order> {
    this.orderId = (Number)(localStorage.getItem("orderId")) || 0

    return this.http.put<Order>("http://localhost:5000/api/Order/save/" + this.orderId, this.orderId)
  }
  ngOnInit() {
    
    this.orderId = (Number)(localStorage.getItem("orderId")) || 0
    this.userId = (Number)(localStorage.getItem("userId")) || 0  
  }
  ngOnChanges() {
    this.orderId = (Number)(localStorage.getItem("orderId")) || 0
    this.userId = (Number)(localStorage.getItem("userId")) || 0

  }
  getBenefits():Observable<number>{
    return this.http.get<number>(this.BASE_URL+"/benefits")
  }
}
