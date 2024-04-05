import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { ListComponent } from './passagem/list/list.component';
import { VooListComponent } from './voo/voo-list/voo-list.component';
import { VooRegisterComponent } from './voo/voo-register/voo-register.component';
import { VooDeleteComponent } from './voo/voo-delete/voo-delete.component';
import { PassagemListComponent } from './passagem/passagem-list/passagem-list.component';
import { PassagemRegisterComponent } from './passagem/passagem-register/passagem-register.component';
import { PassagemDeleteComponent } from './passagem/passagem-delete/passagem-delete.component';
import { VooPassageirosComponent } from './voo/voo-passageiros/voo-passageiros.component';
import { AeroportoPassageirosComponent } from './aeroporto/aeroporto-passageiros/aeroporto-passageiros.component';
import { AeroportoListComponent } from './aeroporto/aeroporto-list/aeroporto-list.component';
import { ToastrModule } from 'ngx-toastr';
import { positionElements } from 'ngx-bootstrap/positioning';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    ListComponent,
    VooListComponent,
    VooRegisterComponent,
    VooDeleteComponent,
    PassagemListComponent,
    PassagemRegisterComponent,
    PassagemDeleteComponent,
    VooPassageirosComponent,
    AeroportoPassageirosComponent,
    AeroportoListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
