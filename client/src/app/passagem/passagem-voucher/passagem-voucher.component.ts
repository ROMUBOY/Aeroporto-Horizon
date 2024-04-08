import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Voucher } from 'src/app/_models/voucher';
import { PassagemService } from 'src/app/_services/passagem.service';

@Component({
  selector: 'app-passagem-voucher',
  templateUrl: './passagem-voucher.component.html',
  styleUrls: ['./passagem-voucher.component.css']
})
export class PassagemVoucherComponent implements OnInit {
  voucher : Voucher | undefined;
  ngOnInit(): void {
    this.loadVoucher();
  }

  constructor(private passagemService : PassagemService, private route : ActivatedRoute){}

  loadVoucher(){
    var id = this.route.snapshot.paramMap.get('id');
    if(!id) return;
    this.passagemService.getPassagem(id).subscribe({
      next: voucher => this.voucher = voucher
    });
  }
}
