import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Voo } from 'src/app/_models/voo';
import { VooService } from 'src/app/_services/voo.service';

@Component({
  selector: 'app-voo-list',
  templateUrl: './voo-list.component.html',
  styleUrls: ['./voo-list.component.css']
})
export class VooListComponent implements OnInit {
  voos : Voo[] = [];

  constructor(private http : HttpClient, private vooService :VooService){}
  
  ngOnInit(): void {
    this.loadVoosDisponiveis();
  }

  loadVoosDisponiveis(){
    this.vooService.getVoosDisponiveis().subscribe({
      next: voos => this.voos = voos
    })
  }
}
