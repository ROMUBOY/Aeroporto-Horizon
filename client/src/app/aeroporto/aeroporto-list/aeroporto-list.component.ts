import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Aeroporto } from 'src/app/_models/aeroporto';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-aeroporto-list',
  templateUrl: './aeroporto-list.component.html',
  styleUrls: ['./aeroporto-list.component.css']
})
export class AeroportoListComponent implements OnInit{
  aeroportos : Aeroporto[] = [];
  baseUrl = environment.apiUrl;

  constructor(private http : HttpClient){}

  ngOnInit(): void {
    this.getAeroportos().subscribe({
      next: aeroportos => this.aeroportos = aeroportos
    });
  }

  getAeroportos(){
    return this.http.get<Aeroporto[]>(this.baseUrl + 'Aeroporto');
  }
}
