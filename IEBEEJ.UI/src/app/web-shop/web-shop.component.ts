import { Component } from '@angular/core';
import { ItemDTO } from '../DTOs/items';
import { ItemsService } from '../services/items.service';

@Component({
  selector: 'app-web-shop',
  templateUrl: './web-shop.component.html',
  styleUrl: './web-shop.component.css'
})
export class WebShopComponent {
  items: ItemDTO[] = []

  constructor(private itemService: ItemsService){}
    ngOnInit(): void {
      this.itemService.getAllItems().subscribe(
        (data) => {
          this.items = data;
        }, 
        (error) => {
          console.error('Error fetching items:', error);
        }
      )
    }
}

