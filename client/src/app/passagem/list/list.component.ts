import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  

  
  passagens : any;

  constructor(private http : HttpClient){}
  
  ngOnInit(): void {
    this.getPassagens();
  }

  getPassagens(){
    this.http.get('http://localhost:5164/api/Aeroporto').subscribe({
      next: response => this.passagens = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }
}
