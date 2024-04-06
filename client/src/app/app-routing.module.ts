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

const routes: Routes = [
  {path: '', component : HomeComponent},
  {path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      {path: 'aeroportos', component : AeroportoListComponent},
      {path: 'passagens/:cpf', component : PassagemListComponent},
      {path: 'passagem/register', component : PassagemRegisterComponent},
      {path: 'passagem/delete', component : PassagemDeleteComponent},
      {path: 'voos', component : VooListComponent},
      {path: 'voo/register', component : VooRegisterComponent}
    ]
  },  
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: NotFoundComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
