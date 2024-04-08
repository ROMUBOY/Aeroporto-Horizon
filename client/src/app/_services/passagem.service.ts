import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Passagem } from '../_models/passagem';
import { environment } from 'src/environments/environment.development';
import { Voucher } from '../_models/voucher';

@Injectable({
  providedIn: 'root'
})
export class PassagemService {
  baseUrl = environment.apiUrl;
  
  passagens: Passagem[] = [];
  
  constructor(private http: HttpClient) { }

  getPassagem(id : any){
    return this.http.get<Voucher>(this.baseUrl + 'Passagem/' + id);
  }

  getPassagens(cpf : any){
    return this.http.get<Voucher[]>(this.baseUrl + 'Passagem/Passageiro/' + cpf);
  }

}
