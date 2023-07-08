import { Component, OnInit } from '@angular/core';

import { Item } from '../classes/item';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-items-details',
  templateUrl: './items-details.component.html',
  styleUrls: ['./items-details.component.css']
})
export class ItemsDetailsComponent implements OnInit {
  items: Item[];

  constructor(private itemsService: ItemsService) { }

  ngOnInit(): void {
    this.refreshItems();
  }

  deleteItem(name: string) {
    this.itemsService.deleteItem(name);
    this.refreshItems();
  }

  private refreshItems() {
    this.items = this.itemsService.getItems();
  }
}
// reference type vs value type

