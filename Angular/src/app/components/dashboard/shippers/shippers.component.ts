import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ShipperServiceService } from '../../service/shipper.service.service';
import { Shippers } from '../../core/models/Shippers_model';

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})

export class ShippersComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['ShipperID', 'CompanyName', 'Phone', 'actions'];
  filterValue: string = '';
  selectedFilter: string = 'all';
  listShippers: Shippers[] = [];
  dataSource = new MatTableDataSource<Shippers>();
  constructor(private shipperService: ShipperServiceService) { }
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngOnInit(): void {
    this.getAllShippers();
  }

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

  editShipper(companyName: string) {
    console.log('Edit:', companyName);
  }

  deleteShipper(companyName: string) {
    console.log('Delete:', companyName);
  }

  getAllShippers() {
    try {
      this.shipperService.getAllShippers().subscribe((res: any) => {
        this.listShippers = res;
        this.dataSource.data = this.listShippers;
      });
    } catch (error) {
      console.log(error);
    }
  }
}
