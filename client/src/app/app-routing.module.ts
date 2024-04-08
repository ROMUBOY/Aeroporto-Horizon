import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AeroportoListComponent } from './aeroporto/aeroporto-list/aeroporto-list.component';
import { PassagemListComponent } from './passagem/passagem-list/passagem-list.component';
import { PassagemRegisterComponent } from './passagem/passagem-register/passagem-register.component';
import { PassagemDeleteComponent } from './passagem/passagem-delete/passagem-delete.component';
import { VooRegisterComponent } from './voo/voo-register/voo-register.component';
import { VooListComponent } from './voo/voo-list/voo-list.component';
import { authGuard } from './_guards/auth.guard';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { VooDetailComponent } from './voo/voo-detail/voo-detail.component';
import { PassagemVoucherComponent } from './passagem/passagem-voucher/passagem-voucher.component';
import { VooPassageirosComponent } from './voo/voo-passageiros/voo-passageiros.component';

const routes: Routes = [
  {path: '', component : HomeComponent},
  {path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      {path: 'aeroportos', component : AeroportoListComponent},      
      {path: 'passagens/register', component : PassagemRegisterComponent},
      {path: 'passagens/delete/:id', component : PassagemDeleteComponent},      
      {path: 'voos/register', component : VooRegisterComponent},
      {path: 'voos/passageiros/:id', component : VooPassageirosComponent}  
    ]
  },  
  {path: 'voos/:id', component : VooDetailComponent},
  {path: 'voos', component : VooListComponent},
  {path: 'passagens/:cpf', component : PassagemListComponent},
  {path: 'voucher/:id', component : PassagemVoucherComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: NotFoundComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
