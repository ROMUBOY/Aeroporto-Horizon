import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'

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
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { VooCardComponent } from './voo/voo-card/voo-card.component';
import { VooDetailComponent } from './voo/voo-detail/voo-detail.component';
import { PassagemVoucherComponent } from './passagem/passagem-voucher/passagem-voucher.component';

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
    AeroportoListComponent,
    NotFoundComponent,
    ServerErrorComponent,
    VooCardComponent,
    VooDetailComponent,
    PassagemVoucherComponent
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
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
