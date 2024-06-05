import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Region {
  Name: string;
  Beschrijving?: string;
  Beautygrade: number;
}

@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  private APIUrl = 'https://localhost:7128/api/Item'

  getAllItems(): Observable<any> {
    const headers = new HttpHeaders({ 
      /** Authorization: `bearer ${this.key}`, */
    })

    return this.HttpClient.get(`${this.APIUrl}/GetAllItems`, { headers })

  }

  getAllItemsFromUser(id:number): Observable<any> {
    const headers = new HttpHeaders({ 
      /** Authorization: `bearer ${this.key}`, */
    })

    return this.HttpClient.get(`${this.APIUrl}/GetItemsBySellerID?id=${id}`, { headers })

  }

  getItemById(id: number): Observable<any> {
    return this.HttpClient.get(`${this.APIUrl}/${id}`)

  }

  getItemByName(name: string|null|undefined): Observable<any>{
    if (name == "" || name ==undefined || name == null ){
      return this.HttpClient.get(`${this.APIUrl}/GetAllItems`)
    } else {
      return this.HttpClient.get(`${this.APIUrl}/SearchOnName?name=${name}`)
    }
  }

  addItem(obj: any) :Observable<any> {
    return this.HttpClient.post(`${this.APIUrl}`, obj)
  }

  constructor(private HttpClient: HttpClient) { }
  
}
