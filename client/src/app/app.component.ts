import { Component , OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Aeroporto Horizon';

  constructor(private http: HttpClient) {}
  aeroportos: any;
  
  ngOnInit() : void {
    this.http.get('http://localhost:5164/api/Aeroporto').subscribe({
      next: response => this.aeroportos = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }
}
