import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { ContaService } from '../_services/conta.service';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  const contaService = inject(ContaService);
  const toastr = inject(ToastrService);

  return contaService.currentUsuario$.pipe(
    map(usuario => {
      if (usuario) return true;
      else{
        toastr.error('usuario não autorizado.');
        return false;
      }
    })
  );
};
