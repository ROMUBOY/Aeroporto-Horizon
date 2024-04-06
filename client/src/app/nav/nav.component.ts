import { Component, OnInit } from '@angular/core';
import { ContaService } from '../_services/conta.service';
import { Observable, of } from 'rxjs';
import { Usuario } from '../_models/usuario';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model : any = {}  

  constructor(public contaService: ContaService, private router : Router,
    private toastr : ToastrService
  ){}

  ngOnInit(): void {       
  }

  login(){
    this.contaService.login(this.model).subscribe({
      next: () => this.router.navigateByUrl('/aeroportos')           
    })
  }

  logout()
  {    
    this.contaService.logout();
    this.router.navigateByUrl('/');
  }
}
