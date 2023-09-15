import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,

  ],
  exports: [
    MatTableModule,
    MatButtonModule,
    MatIconModule, 
  ]
})
export class SharedModule { 
}
