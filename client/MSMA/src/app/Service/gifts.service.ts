import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category, Gift } from '../Models/gift.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Card } from '../Models/card.model';

@Injectable({
  providedIn: 'root'
})
export class GiftsService {

  http: HttpClient = inject(HttpClient);
  BASE_URL = 'http://localhost:5000/api/Gift';


isWasR():Observable<boolean>{
  return  this.http.get<boolean>(this.BASE_URL + "/isRandom")
}
  getAll(): Observable<Gift[]> {

    return this.http.get<Gift[]>(this.BASE_URL);

  }
  getAllGeters(): Observable<Object[]> {

    return this.http.get<Object[]>("http://localhost:5000/api/Card/geters");

  }

  getById(id: number): Observable<Gift> {
    return this.http.get<Gift>(this.BASE_URL + '/' + id);
  }

  update(id: number, item: Gift): Observable<Gift> {
    return this.http.put<Gift>(this.BASE_URL + '/' + id, item);
  }

  add(item: Gift): Observable<Gift> {
  
    var r = this.http.post<Gift>(this.BASE_URL, item);

    return r;
  }

  delete(id: number) {
    var r = this.http.delete(this.BASE_URL + '/' + id);
    alert("נמחק  בהצלחה")
    return r
  }
  random(id: number): Observable<string> {
    var r = this.http.get<string>("http://localhost:5000/api/Card/random/" + id)
    return r;
  }

  selectByCategory(category :Category): Observable<Gift[]> {
    var r = this.http.get<Gift[]>(this.BASE_URL+"/name/" + category)
    return r;
  }

  updateImage(image: File | null = null,id:number) {
    console.log("jhjhjhjh",image)
    const formData = new FormData();
    if (image) {
      formData.append('file', image);
      console.log("image not null");
    }
    return this.http.post(`${this.BASE_URL}/uploadGiftImage?giftId=${id}`, formData, { observe: 'response', responseType: 'text' }).subscribe({
    
    });
  }


}

