import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { WebShopComponent } from './web-shop/web-shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { UserDetailsComponent } from './user-details/user-details.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { LogInComponent } from './log-in/log-in.component';
import { RegisterComponent } from './register/register.component';


const routes: Routes = [
  {path:'', component: HomePageComponent},
  {path:'shop', component: WebShopComponent},
  {path:'items/:id', component: ProductDetailsComponent},
  {path:'account', component: ProductDetailsComponent},
  {path:'login', component: LogInComponent},
  {path:'register', component: RegisterComponent},
  {path:'users', component: ProductDetailsComponent},
  {path:'users/:userId', component: UserDetailsComponent},
  {path:'shopping-cart', component: ShoppingCartComponent}

  
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
