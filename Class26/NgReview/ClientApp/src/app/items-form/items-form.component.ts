import { Component } from '@angular/core';

import { Item } from '../classes/item';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-items-form',
  templateUrl: './items-form.component.html',
  styleUrls: ['./items-form.component.css']
})
export class ItemsFormComponent {
  item: Item = new Item();

  constructor(private itemsService: ItemsService) { }

  onSubmit() {
    this.itemsService.addOrUpdateItem(this.item);
    this.resetItem();
  }

  private resetItem() {
    this.item = new Item();
  }
}
