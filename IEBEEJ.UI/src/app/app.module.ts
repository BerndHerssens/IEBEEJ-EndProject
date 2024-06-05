import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { NavbarComponent } from './navbar/navbar.component';
import { WebShopComponent } from './web-shop/web-shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { AccountComponent } from './account/account.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { FooterComponent } from './footer/footer.component';
import { LogInComponent } from './log-in/log-in.component';
import { RegisterComponent } from './register/register.component';
import { Routes } from '@angular/router';
import { UserDetailsComponent } from './user-details/user-details.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {provideNativeDateAdapter} from '@angular/material/core';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { AddItemComponent } from './add-item/add-item.component';





@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    WebShopComponent,
    ProductDetailsComponent,
    AccountComponent,
    ShoppingCartComponent,
    FooterComponent,
    LogInComponent,
    UserDetailsComponent,
    AddItemComponent
  ],
  imports: [
    BrowserModule,
    NavbarComponent,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatInputModule,
    MatFormFieldModule,
    
    
  ],
  providers: [provideNativeDateAdapter(), provideAnimationsAsync()],
  bootstrap: [AppComponent]
})
export class AppModule { }

export const routes: Routes = [
  { path: 'web-shop', component: WebShopComponent },
  { path: 'product-details', component: ProductDetailsComponent },
  { path: 'account', component: AccountComponent },
  { path: 'shopping-cart', component: ShoppingCartComponent },
  { path: 'log-in', component: LogInComponent },
  { path: 'register', component: RegisterComponent }
];
