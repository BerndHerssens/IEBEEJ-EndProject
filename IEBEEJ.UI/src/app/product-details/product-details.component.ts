import { Component } from '@angular/core';
import { ItemsService } from '../services/items.service';
import { HttpClient } from '@angular/common/http';
import { ItemDTO } from '../DTOs/items';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { BidsService } from '../services/bids.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent {

  item: any;
  loggedInUser: any;
  
  addBid = new FormGroup ({
    bidValue: new FormControl(''),
  })

  constructor(private itemService: ItemsService, private userService : UserService, private route: ActivatedRoute, private bidService : BidsService, private router : Router){
    this.route.params.subscribe(parameters => {
      const id = parameters['id']
      this.itemService.getItemById(id).subscribe(item => {
        this.item = item;
      })
    });
    this.loggedInUser = this.userService.currentUser;
  }

  placeBid(){
    this.bidService.addBid({
      bidValue: this.addBid.value.bidValue,
      bidderId: this.userService.currentUser.id,
      itemId: this.item.id
    }).subscribe(
      (data) => {
        this.router.navigate([`/items/${this.item.id}`])
        
      }, 
      (error) => {
        console.error(error)
        alert("Your offer was not accepted due to it being too low")
      }
    )
  }
}
