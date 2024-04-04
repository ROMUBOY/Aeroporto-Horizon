import { Component , OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { ContaService } from './_services/conta.service';
import { Usuario } from './_models/usuario';

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
    this.getAeroportos();
    this.setCurrentUsuario();
  }

  getAeroportos(){
    this.http.get('http://localhost:5164/api/Aeroporto').subscribe({
      next: response => this.aeroportos = response,
      error: error => console.log(error),
      complete: () => console.log("Request has completed")
    })
  }

  setCurrentUsuario(){
    const usuarioString = localStorage.getItem('usuario');
    if(!usuarioString) return;
    const usuario : Usuario = JSON.parse(usuarioString);
    this.contaService.setCurrentUsuario(usuario);
  }
}
