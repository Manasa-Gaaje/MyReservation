import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class projectService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }), 
  };
  constructor(private http: HttpClient) {}
  getData() {
    return this.http.get('https://localhost:44372/api/Res/GetResDetails');
  }
  // postData(datas: any) {
  //   return this.http
  //     .post('https://localhost:44344/api/Home/insert', datas, this.httpOptions)
  //     .subscribe();
  // }

  addData(data:any)
  {
    return this.http.post('https://localhost:44372/api/Res/insert',data,this.httpOptions).subscribe();
  }
  deleteData(data:number){
    return this.http.delete('https://localhost:44372/api/Res/Delete/' +data,this.httpOptions).subscribe();
  }
  
}
