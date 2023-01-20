import { DecimalPipe } from '@angular/common';
import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { formatDate } from '@angular/common';
import { MatDialog,MAT_DIALOG_DATA,MatDialogRef} from '@angular/material/dialog';
import { AddComponent } from '../add/add.component';

import { projectService } from 'src/app/project.service';
import { DeleteComponent } from '../delete/delete.component';
import { LoginComponent } from '../login.component';
import { FormBuilder,FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs/internal/Observable';
import { MatSort,Sort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { LiveAnnouncer } from '@angular/cdk/a11y';


// export interface PeriodicElement {
//   id: number;
//   Hotel: string;
//   Arrival: Date;
//   Departure: Date;
//   Type: string;
//   Guests: number;
//   price: number;
//   Manage: string;
// }

// const ELEMENT_DATA: PeriodicElement[] = [];

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent implements OnInit {
  loginForm!: FormGroup;
  //search: any = null;
  // loginform = new FormGroup({
  // // displayedColumns: string[] = [
  //   id:new FormControl(''),
  //   Hotel:new FormControl(''),
  //   Arrival:new FormControl(''),
  //  Depature:new FormControl(''),
  //   Type:new FormControl(''),
  //   Guests:new FormControl(''),
  //   price:new FormControl(''),
  // })
  //data: any = null;
  // myControl = new FormControl('');

  // data:any = new MatTableDataSource()
  displayedColumns: string[] = ['id', 'Hotel', 'Arrival', 'Depature','Type','Guests','price','Manage'];
  datasource!:MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) matSort!: MatSort
  
  

  // constructor(private ds: projectService, private dialog: MatDialog,private route:Router) {
  //   this.ds.getData().subscribe((x) => {
  //     this.data = x;
  //     console.log(this.data);
  //   });
  // }
  constructor(private ds:projectService,private dialog: MatDialog,private formBuilder: FormBuilder,private _liveAnnouncer: LiveAnnouncer,private route:Router){
    
  }
  list:any=[];
  
  ngOnInit() {
    this.ds.getData().subscribe((ss:any)=>{
      this.datasource=new MatTableDataSource(ss);
      this.datasource.paginator=this.paginator;
      this.datasource.sort=this.matSort;
    console.log(this.datasource);
   });
  }
  openDialog() {
    this.dialog.open(AddComponent, {
      height: '90%',
      width: '90%',
    }).afterClosed();
  }
  // save(){
  //   let DataForm = JSON.stringify(this.loginform.value)
  //   console.log(DataForm);
  //   this.data.insert(DataForm);
  //   window.location.reload();

  // }
  clEdit(value: number) {
      console.log(value);
      this.dialog.open(AddComponent,{
        height:'90%',
        width:'90%',
        data:value
      })
    }

  clDelete(id: number) {
    console.log(id);
    this.ds.deleteData(id);
     window.location.reload();
  }
  backToHome(){
  this.route.navigate([''])
  }
  announceSortChange(sortState: Sort) {

  
  if (sortState.direction) {
    this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
  } else {
    this._liveAnnouncer.announce('Sorting cleared');
  }
}
filterData($event :any)
  {
    this.datasource.filter=$event.target.value;
  }
}





