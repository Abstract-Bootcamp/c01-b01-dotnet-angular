import { Component, Input } from '@angular/core';

import { Category } from '../interfaces/category';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.scss']
})
export class CategoriesListComponent {
  @Input() items: Category[] = [];

}
