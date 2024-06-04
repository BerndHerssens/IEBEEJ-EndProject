import { Component } from '@angular/core';
import { ItemsService } from '../services/items.service';
import { BidsService } from '../services/bids.service';
import { ItemDTO } from '../DTOs/items';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.css'
})
export class AccountComponent {
  constructor(private itemService: ItemsService, private bidService: BidsService){}

  items: ItemDTO[] = []

  ngOnInit(): void {
    this.itemService.getAllItems().subscribe(
      (data) => {
        this.items = data;
        console.log(this.items);
        this.items.forEach(item => {
          let highestBid = this.bidService.getHighestBid(item.allBids);
          if (highestBid != null) {
            item.highestBidPrice = highestBid.bidValue;
          }
          else 
            item.highestBidPrice = undefined;
        });
      }, 
      (error) => {
        console.error('Error fetching items:', error);
      }
    )
  }

}
