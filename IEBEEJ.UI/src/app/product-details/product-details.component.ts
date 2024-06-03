import { Component } from '@angular/core';
import { ItemsService } from '../services/items.service';
import { HttpClient } from '@angular/common/http';
import { ItemDTO } from '../DTOs/items';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent {

  item: any;
  bidValue: number = 0;

  constructor(private itemService: ItemsService, private route: ActivatedRoute){
    this.route.params.subscribe(parameters => {
      const id = parameters['id']
      this.itemService.getItemById(id).subscribe(item => {
        this.item = item
        console.log(item)
      })
    })
  }
}
