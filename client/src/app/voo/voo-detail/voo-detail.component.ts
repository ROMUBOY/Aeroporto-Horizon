import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { Passagem } from 'src/app/_models/passagem';
import { Voo } from 'src/app/_models/voo';
import { VooService } from 'src/app/_services/voo.service';

@Component({
  selector: 'app-voo-detail',
  templateUrl: './voo-detail.component.html',
  styleUrls: ['./voo-detail.component.css']
})
export class VooDetailComponent implements OnInit {
  voo : Voo | undefined;
  passagem : any = {};

  constructor(private vooService: VooService, private route: ActivatedRoute, private router : Router, private toastr : ToastrService){}

  ngOnInit(): void {
    this.loadVoo();
  }

  loadVoo(){
    var id = this.route.snapshot.paramMap.get('id');
    if(!id) return;
    this.vooService.getVoo(id).subscribe({
      next: voo => this.voo = voo
    });
  }

  registerPassagem(){    
    this.passagem.id = 0;
    this.passagem.bagagem = "";
    this.passagem.valor = this.voo?.valor;
    this.passagem.vooId = this.voo?.id;
    this.vooService.postPassagem(this.passagem as Passagem).subscribe({
      next : () => {
        this.router.navigateByUrl('/voos') 
        this.toastr.success("Passagem comprada com sucesso.");
      }      
    });
  }
}
