import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { projectService } from 'src/app/project.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
})
export class AddComponent implements OnInit {
  add:any;
  

  constructor(private ds:projectService,@Inject(MAT_DIALOG_DATA) public data:any) {}
  ngOnInit(): void {
    console.log(this.data)
    this.add=new FormGroup({

      id: new FormControl(''),
      Hotel: new FormControl(''),
      Arrival: new FormControl(''),
      Depature: new FormControl(''),
      Type: new FormControl(''),
      Guests: new FormControl(''),
      price: new FormControl(''),
    });
      let Adate = this.data.Arrival.split('T');
      let Ddate = this.data.Depature.split('T');
      this.add.patchValue({
        id: this.data.id,
        Hotel: this.data.Hotel,
        Arrival: Adate[0],
        Depature: Ddate[0],
        Type: this.data.Type,
        Guests: this.data.Guests,
        price: this.data.price,
      });
    }

    
  
  
  save() {
    console.log(this.add.value);
    let serializedForm = JSON.stringify(this.add.value);
    console.log(serializedForm);
    // console.log(this.ds);
    this.ds.addData(serializedForm);
     window.location.reload();
  }
}
