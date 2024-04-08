import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../_models/usuario';
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ContaService {
  baseUrl = environment.apiUrl;
  private currentUsuarioSource = new BehaviorSubject<Usuario | null>(null);
  currentUsuario$ = this.currentUsuarioSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: Usuario)
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
