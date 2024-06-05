import { Component } from '@angular/core';
import { ItemsService } from '../services/items.service';
import { BidsService } from '../services/bids.service';
import { ItemDTO } from '../DTOs/items';
import { UserService } from '../services/user.service';
import { UserDTO } from '../DTOs/users';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.css'
})
export class AccountComponent {
  constructor(private itemService: ItemsService, private bidService: BidsService, private userService:UserService){}

  items: ItemDTO[] = []

  user : UserDTO = this.userService.currentUser

  ngOnInit(): void {
    this.itemService.getAllItemsFromUser(this.userService.currentUser.id).subscribe(
      (data) => {
        this.items = data;
        this.items.forEach(item => {
          let highestBid = this.bidService.getHighestBid(item.allBids);
          if (highestBid != null) {
            item.highestBidPrice = highestBid.bidValue;
          }
          else 
            item.highestBidPrice = undefined;
        });
        console.log(this.items)
      }, 
      (error) => {
        console.error('Error fetching items:', error);
      }
    )
  }

}
