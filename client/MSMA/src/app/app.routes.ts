import { Routes } from '@angular/router';
import { ListGiftsComponent } from './Components/gifts/list-gifts/list-gifts.component';
import { EditGiftComponent } from './Components/gifts/edit-gift/edit-gift.component';
import { RegisterComponent } from './Components/users/register/register.component';
import { LoginComponent } from './Components/users/login/login.component';
import { AddGiftComponent } from './Components/gifts/add-gift/add-gift.component';
import { AddDonorComponent } from './Components/donors/add-donor/add-donor.component';
import { ListDonorsComponent } from './Components/donors/list-donors/list-donors.component';
import { AppComponent } from './app.component';
import { ListOrdersComponent } from './Components/cards/list-orders/list-orders.component';
import { MsmaComponent } from './Components/msma/msma.component';

export const routes: Routes = [

    
    // {path:'gifts', component:ListGiftsComponent,
    //     children:[
    //         // {path:'/', component:ListGiftsComponent},
    //         {path:'/:id', component:EditGiftComponent},
       
    //     ]
    // },
    // {path:'', redirectTo:'gifts', pathMatch:'full'},
    {path:'login', component:LoginComponent},
    {path:'register', component:RegisterComponent},
    {path:'gifts', component:ListGiftsComponent},
    {path:'gifts/addGift', component:AddGiftComponent},
    {path:'gifts/:id', component:EditGiftComponent},
    {path:'donors', component:ListDonorsComponent},
    {path:'donors/add', component:AddDonorComponent},
    {path:'card', component:ListOrdersComponent},
    {path:'', component:MsmaComponent}

];
//ListOrdersComponent

    // {path:'receipe-book', component:ReceipeBookComponent, children:[
    //     {path:'', component:ReceipeListComponent},
    //     {path:'add', component:ReceipeEditComponent},
    //     {path:'edit/:id', component:ReceipeEditComponent}
    // ]},
    // {path:'providers', component:providersComponent},
    // {path:'', redirectTo:'start-learning', pathMatch:'full'},
