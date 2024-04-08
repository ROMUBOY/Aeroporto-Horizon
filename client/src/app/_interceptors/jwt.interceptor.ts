import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { ContaService } from '../_services/conta.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private accountService: ContaService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.accountService.currentUsuario$.pipe(take(1)).subscribe({
      next: usuario => {
        if (usuario) {
          request = request.clone({
            setHeaders: {
              Authorization: `Bearer ${usuario.token}`
            }
          })
        }
      }
    })
    return next.handle(request);
  }
}
