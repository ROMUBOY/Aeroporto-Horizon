import { Component, OnInit } from '@angular/core';
import { ContaService } from '../_services/conta.service';
import { Observable, of } from 'rxjs';
import { Usuario } from '../_models/usuario';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model : any = {}  

  constructor(public contaService: ContaService){}

  ngOnInit(): void {       
  }

  login(){
    this.contaService.login(this.model).subscribe({
      next: response => {
        console.log(response);        
      },
      error: error => console.log(error)      
    })
  }

  logout()
  {
    this.contaService.logout();    
  }
  

}
