import { Directive, ElementRef, HostListener, Output, EventEmitter, Input, HostBinding } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';



export interface CustomSortEvent {
  column: string;
  direction: string;
  grid:string;
}

@Directive({
  selector: '[dtHeader]',  
})
export class DtHeaderDirective {


  constructor(private el: ElementRef) {     
    // this.el.nativeElement.style.backgroundColor='yellow';
    this.el.nativeElement.style.cursor='pointer';    
    //let caption = this.el.nativeElement.innerHTML;
    EventEmitterService.get('sort').subscribe(p=>{
      if (p.column!=this.field && p.grid==this.grid){
        this.elementClass='---';
      }
    })
  }


  @HostBinding('class')
  elementClass = '';

  @Output() sort = new EventEmitter<CustomSortEvent>();
  @Input() field: string;
  @Input() grid: string;

  state='---';
  @HostListener('click') rotate() {     
    if (this.state=='---')
    {
      this.state='asc';      
    }
    else if (this.state=='asc'){
      this.state='desc';
      
    }
    else if (this.state=='desc'){
      this.state='asc';
    }
    this.elementClass=this.state;
    this.sort.emit({ column: this.field, direction: this.state,grid:this.grid });
  }

}
