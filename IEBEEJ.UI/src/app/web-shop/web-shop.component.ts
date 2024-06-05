import { Component } from '@angular/core';
import { ItemDTO } from '../DTOs/items';
import { ItemsService } from '../services/items.service';
import { FormControl, FormGroup } from '@angular/forms';
import { BidsService } from '../services/bids.service';

@Component({
  selector: 'app-web-shop',
  templateUrl: './web-shop.component.html',
  styleUrl: './web-shop.component.css'
})
export class WebShopComponent {
  
  items: ItemDTO[] = []

  searchQuery = new FormGroup ({
    searchQuery: new FormControl(''),
  })

  constructor(private itemService: ItemsService, private bidService: BidsService){}

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

  searchOnName() {
    const obj = this.searchQuery.value;
    this.itemService.getItemByName(obj.searchQuery).subscribe(
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
      }, 
      (error) => {
        console.error('Error fetching items:', error);
      }
    )
  }

  
}

