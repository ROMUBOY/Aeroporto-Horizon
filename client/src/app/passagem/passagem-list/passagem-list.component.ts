import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Passagem } from 'src/app/_models/passagem';
import { Voucher } from 'src/app/_models/voucher';
import { PassagemService } from 'src/app/_services/passagem.service';

@Component({
  selector: 'app-passagem-list',
  templateUrl: './passagem-list.component.html',
  styleUrls: ['./passagem-list.component.css']
})
export class PassagemListComponent implements OnInit {

  vouchers : Voucher[] = [];

  constructor(private route : ActivatedRoute, private passagemService : PassagemService){}

  ngOnInit(): void {
    var cpf = this.route.snapshot.paramMap.get('cpf');
    this.passagemService.getPassagens(cpf).subscribe({
      next: vouchers => this.vouchers = vouchers
    });
  }
}
