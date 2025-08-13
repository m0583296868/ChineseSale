import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Donor } from '../Models/donor.model';
@Injectable({
  providedIn: 'root'
})
export class DonorsService {

  BASE_URL = 'http://localhost:5000/api/Donor';

  http: HttpClient = inject(HttpClient);
  add(item: Donor): Observable<Donor>{
    return this.http.post<Donor>(this.BASE_URL, item);
   
  }
  getAll(): Observable<Donor[]>{
    var v=this.http.get<Donor[]>(this.BASE_URL);
    var vv=v.subscribe(data=>{})
    return this.http.get<Donor[]>(this.BASE_URL);
  }
}