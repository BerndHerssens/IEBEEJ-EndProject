import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomePageComponent } from './home-page/home-page.component';
import { WebShopComponent } from './web-shop/web-shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { AccountComponent } from './account/account.component';
import { ContactComponent } from './contact/contact.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { FooterComponent } from './footer/footer.component';
import { LogInComponent } from './log-in/log-in.component';
import { RegisterComponent } from './register/register.component';
import { Routes } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavbarComponent,
    HomePageComponent,
    WebShopComponent,
    ProductDetailsComponent,
    AccountComponent,
    ContactComponent,
    ShoppingCartComponent,
    FooterComponent,
    LogInComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

export const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'web-shop', component: WebShopComponent },
  { path: 'product-details', component: ProductDetailsComponent },
  { path: 'account', component: AccountComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'shopping-cart', component: ShoppingCartComponent },
  { path: 'log-in', component: LogInComponent },
  { path: 'register', component: RegisterComponent }
];
