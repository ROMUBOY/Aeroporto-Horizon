import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../_models/usuario';
import { BehaviorSubject, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContaService {
  baseUrl = 'http://localhost:5164/api/'
  private currentUsuarioSource = new BehaviorSubject<Usuario | null>(null);
  currentUsuario$ = this.currentUsuarioSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any)
  {
    return this.http.post<Usuario>(this.baseUrl + 'Login', model).pipe(
      map((response: Usuario) => {
        const usuario = response;
        if (usuario){
          localStorage.setItem('usuario', JSON.stringify(usuario))
          this.currentUsuarioSource.next(usuario);
        }
      })
    );
  }

  setCurrentUsuario(usuario :Usuario){
    this.currentUsuarioSource.next(usuario);
  }

  logout(){
    localStorage.removeItem('usuario');
    this.currentUsuarioSource.next(null);
  }
}
