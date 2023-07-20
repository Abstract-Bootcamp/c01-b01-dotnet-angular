import { Component } from '@angular/core';

@Component({
  selector: 'app-items-container',
  templateUrl: './items-container.component.html',
  styleUrls: ['./items-container.component.css']
})
export class ItemsContainerComponent {

  test = "this value from parent component";
  outputValue = '';

  onFormSubmit(value: string) {
    this.outputValue = value;
  }
}
