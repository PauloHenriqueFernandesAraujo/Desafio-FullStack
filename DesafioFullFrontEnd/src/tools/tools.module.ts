import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericService } from './generic/genericService.service';
import { GenericController } from './generic/genericController.service';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
  ],
  exports: [],
  providers: [
    GenericService,
    GenericController
  ]
})
export class ToolsModule { }
