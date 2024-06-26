import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WebShopComponent } from './web-shop/web-shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { LogInComponent } from './log-in/log-in.component';
import { RegisterComponent } from './register/register.component';
import { AccountComponent } from './account/account.component';
import { AddItemComponent } from './add-item/add-item.component';


const routes: Routes = [
  {path:'',component: LogInComponent},
  {path:'shop', component: WebShopComponent},
  {path:'items/:id', component: ProductDetailsComponent},
  {path:'account', component: AccountComponent},
  {path:'login', component: LogInComponent},
  {path:'register', component: RegisterComponent},
  {path:'shopping-cart', component: ShoppingCartComponent},
  {path:'add-item', component: AddItemComponent}

  
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
