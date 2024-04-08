import { Component , OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { ContaService } from './_services/conta.service';
import { Usuario } from './_models/usuario';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Aeroportos';

  constructor(private http: HttpClient, private contaService : ContaService) {}
  aeroportos: any;
  
  ngOnInit() : void {    
    this.setCurrentUsuario();
  }  

  setCurrentUsuario(){
    const usuarioString = localStorage.getItem('usuario');
    if(!usuarioString) return;
    const usuario : Usuario = JSON.parse(usuarioString);
    this.contaService.setCurrentUsuario(usuario);
  }
}
