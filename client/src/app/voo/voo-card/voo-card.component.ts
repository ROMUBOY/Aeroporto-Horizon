import { Component, Input, OnInit } from '@angular/core';
import { Voo } from 'src/app/_models/voo';
import { ContaService } from 'src/app/_services/conta.service';

@Component({
  selector: 'app-voo-card',
  templateUrl: './voo-card.component.html',
  styleUrls: ['./voo-card.component.css']
})
export class VooCardComponent implements OnInit {
  @Input() voo : Voo | undefined;

  constructor(public contaService : ContaService){}

  ngOnInit(): void {
    
  }

}
