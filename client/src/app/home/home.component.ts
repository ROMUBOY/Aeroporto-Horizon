import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  model : any = {};
  checarPassagemMode = false;

  constructor(private router : Router) {}

  ngOnInit(): void {
    
  }

  compraPassagemToggle(){
    this.router.navigateByUrl('/voos');
  }

  checarPassagensporCpfToggle(){
    this.checarPassagemMode = true;
  }

  redirectPassagemList(){    
    if(!this.model) return;

    this.checarPassagemMode = false;  
    
    this.router.navigateByUrl('/passagens/' + this.model.cpf);
  }
}
