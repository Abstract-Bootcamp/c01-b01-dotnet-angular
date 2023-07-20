import { Component, EventEmitter, Input, Output } from '@angular/core';

import { Item } from '../classes/item';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-items-form',
  templateUrl: './items-form.component.html',
  styleUrls: ['./items-form.component.css']
})
export class ItemsFormComponent {
  @Input() testInput: string;
  @Output() testOutput = new EventEmitter<string>();

  item: Item = new Item();// address x002

  constructor(private itemsService: ItemsService) { }

  onSubmit() {
    this.itemsService.addOrUpdateItem(this.item);
    this.testOutput.emit("this value from child component: " + this.item.name);
    this.resetItem();
  }

  private resetItem() {
    this.item = new Item();//x002
  }
}
