import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Passageiro } from 'src/app/_models/passageiro';
import { Passagem } from 'src/app/_models/passagem';
import { Voo } from 'src/app/_models/voo';
import { VooService } from 'src/app/_services/voo.service';

@Component({
  selector: 'app-voo-passageiros',
  templateUrl: './voo-passageiros.component.html',
  styleUrls: ['./voo-passageiros.component.css']
})
export class VooPassageirosComponent {
  voo : Voo | undefined;
  passageiros : Passageiro[] = [];

  constructor(private vooService: VooService, private route: ActivatedRoute, private router : Router, private toastr : ToastrService){}

  ngOnInit(): void {
    this.loadVoo();
    this.loadPassageiros();
  }

  loadVoo(){
    var id = this.route.snapshot.paramMap.get('id');
    if(!id) return;
    this.vooService.getVoo(id).subscribe({
      next: voo => this.voo = voo
    });
  }

  loadPassageiros(){    
    var id = this.route.snapshot.paramMap.get('id');
    this.vooService.getPassageiros(id).subscribe({
      next: passageiros => this.passageiros = passageiros
    });
  }
}
