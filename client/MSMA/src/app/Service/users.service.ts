import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Users } from '../Models/user.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { resUser } from '../Models/resUser.model';
@Injectable({
  providedIn: 'root'
})
export class UsersService {


 BASE_URL = 'http://localhost:5000/api/User';

  http: HttpClient = inject(HttpClient);
  add(item: Users): Observable<Users>{
    return this.http.post<Users>(this.BASE_URL+'/register', item);
   
  }
  login(username:string,password:string): Observable<resUser>{

var a=this.http.post<resUser>(this.BASE_URL+'/login?userName='+username+'&password='+password,null
);

      return a;
 }
}



  