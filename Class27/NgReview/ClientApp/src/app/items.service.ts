import { Injectable } from '@angular/core';

import { Item } from './classes/item';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  private items: Item[] = [];

  getItems(): Item[] {
    return this.items;
  }

  getItem(name: string): Item {
    return this.items.find(item => item.name === name) ?? new Item();
  }

  addOrUpdateItem(item: Item): void {
    const index = this.items.findIndex(i => i.name === item.name);
    if (index !== -1) {
      this.updateItem(index, item);
    } else {
      this.addItem(item);
    }
  }

  private addItem(item: Item): void {
    this.items.push(item);
  }

  private updateItem(index: number, item: Item): void {
    this.items[index] = item;
  }

  // a, b ,c ,d ,e
  // input = b
  // output = a, c, d, e = new list
  deleteItem(name: string): void {
    this.items = this.items.filter(item => item.name !== name);
  }
}
