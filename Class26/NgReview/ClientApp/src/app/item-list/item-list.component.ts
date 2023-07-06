import { Component, OnInit } from '@angular/core';

import { Item } from '../items-interfaces/item';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {
  items: Item[];

  constructor(private itemService: ItemsService) { }

  ngOnInit() {
    this.items = this.itemService.getItems();
  }

  onDelete(index: number) {
    this.itemService.deleteItem(this.items[index].name);
    this.items = this.itemService.getItems();
  }
}
