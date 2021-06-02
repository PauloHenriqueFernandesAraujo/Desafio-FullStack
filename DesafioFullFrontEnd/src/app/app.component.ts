import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GenericController } from 'src/tools/generic/genericController.service';
import { GenericService } from 'src/tools/generic/genericService.service';

const debtsRoute = "debts";
const debtInstallmentRoute = "debtInstallment";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent extends GenericController implements OnInit {

  /* Forms*/
  debtsForm: FormGroup = this.formBuilder.group({
    _Id: [null, Validators.nullValidator],
    Id: [null, Validators.nullValidator],
    NumeroDotitulo: [null, Validators.required],
    NomeDoDevedor: [null, Validators.required],
    CPFDoDevedor: [null, Validators.required],
    Juros: [null, Validators.required],
    Multa: [null, Validators.required],
  });;

  debtInstallmentForm: FormGroup = this.formBuilder.group({
    _Id: [null, Validators.nullValidator],
    Id: [null, Validators.nullValidator],
    DebtsId: [null, Validators.nullValidator],
    NumeroDaParcela: [null, Validators.required],
    DataDeVencimento: [null, Validators.required],
    ValorDaParcela: [null, Validators.required],
  });;

  /* show Forms*/
  formDebts: boolean = false;
  formdebtInstallment: boolean = false;

  /* Table data*/
  tableDebts: any = [];
  tableDebtInstallment: any = [];

  constructor(public genericService: GenericService, public formBuilder: FormBuilder) {
    super(genericService);
  }

  async ngOnInit() {
    this.tableDebts = await this.genericService.get(debtsRoute + "/table");
  }

  async onBackDivida() {
    this.tableDebts = await this.genericService.get(debtsRoute + "/table");
    this.formDebts = false;
    this.debtsForm.reset();
  }

  async onBackParcela() {
    this.tableDebtInstallment = await this.genericService.get(debtInstallmentRoute + "/table/" + this.debtsForm.controls['_Id'].value);
    this.formdebtInstallment = false;
    this.debtInstallmentForm.reset();
  }

  onNewDivida() {
    this.debtsForm.reset();
    this.formDebts = true;
  }

  onNewParcela() {
    this.debtInstallmentForm.reset();
    this.formdebtInstallment = true;
  }

  async onCreate(route: string) {
    switch (route) {

      case debtsRoute: {

        if (this.debtsForm.valid) {

          await this.onSave(route, this.debtsForm.value).then(async response => {
            if (response._Id) {

              this.debtsForm.controls['_Id'].patchValue(response._Id);
              this.tableDebtInstallment = await this.genericService.get(debtInstallmentRoute + "/table/" + response._Id);
              this.formdebtInstallment = false;
            }
          });

        }
        break;
      }

      case debtInstallmentRoute: {
        if (this.debtInstallmentForm.valid) {

          this.debtInstallmentForm.controls["DebtsId"].setValue(this.debtsForm.controls['_Id'].value);
          await this.onSave(route, this.debtInstallmentForm.value).then(async response => {
            if (response._Id) {
              
              this.debtInstallmentForm.controls['_Id'].patchValue(response._Id);
              this.tableDebtInstallment = await this.genericService.get(debtInstallmentRoute + "/table/" + this.debtsForm.controls['_Id'].value);
            }
          });

        }
        break;
      }

    }
  }

  async onEditar(route: string, id: string) {
    switch (route) {

      case debtsRoute: {

        await this.onEdit(route, id).then(async response => {
          
          if (response._Id) {
            this.debtsForm.patchValue(response);

            this.tableDebtInstallment = await this.genericService.get(debtInstallmentRoute + "/table/" + response._Id);
            this.formdebtInstallment = false;
            this.formDebts = true;
          }

        });
        break;
      }

      case debtInstallmentRoute:{

        await this.onEdit(route, id).then(async response => {
          
          if (response._Id) {
            this.debtInstallmentForm.patchValue(response);
            this.formdebtInstallment = true;
          }

        });
        break;
      }

    }
  }

  async onExcluir(route: string, id: string) {
    switch (route) {

      case debtsRoute: {

        this.tableDebtInstallment = await this.genericService.get(debtInstallmentRoute + "/table/" + id);
        this.tableDebtInstallment.forEach(async (item : any)=> {
          await this.onExcluir(debtInstallmentRoute,item._Id);
        });

        await this.onDelete(route, id).then(async response => {
          if (response) {
            this.tableDebts = await this.genericService.get(debtsRoute + "/table");
          }

        });
        break;
      }

      case debtInstallmentRoute:{

        await this.onDelete(route, id).then(async response => {
          if (response) {
            this.tableDebtInstallment = await this.genericService.get(debtInstallmentRoute + "/table/" + this.debtsForm.controls['_Id'].value);
          }

        });
        break;
      }

    }

  }


  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }
}