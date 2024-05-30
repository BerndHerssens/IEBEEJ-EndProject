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

  constructor(private HttpClient: HttpClient) { }
  
}
