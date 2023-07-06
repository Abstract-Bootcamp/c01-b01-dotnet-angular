import { Component, OnInit } from '@angular/core';

import { Item } from '../items-interfaces/item';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-item-form',
  templateUrl: './item-form.component.html',
  styleUrls: ['./item-form.component.css']
})
export class ItemFormComponent implements OnInit {
  item: Item = new Item();

  constructor(private itemService: ItemsService) { }

  ngOnInit() {
  }

  onSubmit(): void {
    this.itemService.addOrUpdateItem(this.item);
    this.item = new Item(); // Clear the form
  }
}