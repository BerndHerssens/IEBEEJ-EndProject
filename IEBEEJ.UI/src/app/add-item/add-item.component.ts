import { Component } from '@angular/core';
import { ItemsService } from '../services/items.service';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrl: './add-item.component.css'
})
export class AddItemComponent {
  newItem = new FormGroup({
    itemName: new FormControl(''),
    itemDescription: new FormControl(''),
    sendingAdress: new FormControl(''),
    startingPrice: new FormControl(''),
  });

  constructor(private userService : UserService, private itemService : ItemsService) {}
  
  createItem() {
    let itemToAdd = {
      ...this.newItem.value,
      sellerId: this.userService.currentUser.id,
      categoryId:1
    }
    console.log(itemToAdd);
    
    this.itemService.addItem(itemToAdd).subscribe(
      (data) => {
        this.userService.currentUser = data;
        alert("Item toegevoegd!")
      }, 
        (error) => {
          console.error(error)
          alert("U gaf niet de juiste waarden op")
        }
      
    )
  }
}
