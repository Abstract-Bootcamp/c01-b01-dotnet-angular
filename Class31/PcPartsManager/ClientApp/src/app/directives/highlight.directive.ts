import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[html-highlight]'
})
export class HighlightDirective {

  constructor(private el: ElementRef) {
    this.el.nativeElement.style.backgroundColor = 'yellow';
  }

}
