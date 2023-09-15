import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';



export interface Shippers {
  companyName: string;
  phone: string;
}

const listShippers: Shippers[] = [
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},

];

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})


export class ShippersComponent implements OnInit {
  displayedColumns: string[] = ['companyName', 'phone'];
  dataSource = new MatTableDataSource(listShippers);
  filterValue: string = ''; // Propiedad para almacenar el valor del filtro
  selectedFilter: string = 'all'; // Propiedad para almacenar la opción de filtro seleccionada

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() {}
  ngOnInit(): void {}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
   this.dataSource.sort = this.sort;
  }
  

  applyFilter() {
    if (this.selectedFilter === 'all') {
      this.dataSource.filter = '';
    } else {
      this.dataSource.filter = this.filterValue.trim().toLowerCase();
    }
  }
}