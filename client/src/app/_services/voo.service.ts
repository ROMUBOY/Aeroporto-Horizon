import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Voo } from '../_models/voo';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';
import { Passagem } from '../_models/passagem';
import { Passageiro } from '../_models/passageiro';

@Injectable({
  providedIn: 'root'
})
export class VooService {
  baseUrl = environment.apiUrl;
  voos: Voo[] = [];
  constructor(private http: HttpClient) { }

  getVoos(){
    return this.http.get<Voo>(this.baseUrl + 'Voo');
  }

  getVoosDisponiveis(){
    return this.http.get<Voo[]>(this.baseUrl + 'Voo/Disponiveis');
  }

  getVoo(id : string){
    return this.http.get<Voo>(this.baseUrl + 'Voo/' + id);
  }

  getPassageiros(id : any){
    return this.http.get<Passageiro[]>(this.baseUrl + 'Voo/Passageiros/' + id);
  }

  postPassagem(model: any) {
    return this.http.post<Passagem>(this.baseUrl + 'Passagem', model);
  }
}
