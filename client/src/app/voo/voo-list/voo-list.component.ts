import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-voo-list',
  templateUrl: './voo-list.component.html',
  styleUrls: ['./voo-list.component.css']
})
export class VooListComponent implements OnInit {
  voos : any;

  constructor(private http : HttpClient){}
  
  ngOnInit(): void {
    this.getVoos();
  }

  getVoos(){
    this.http.get('http://localhost:5164/api/Voo/Disponiveis').subscribe({
      next: response => this.voos = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }
}
