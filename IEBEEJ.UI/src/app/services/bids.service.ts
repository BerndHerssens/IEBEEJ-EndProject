import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BidsService {

  
  private APIUrl = 'https://localhost:7128/api/Bid'
  
  getAllBidsByItemID(itemId: number): Observable<any> {
    const headers = new HttpHeaders({ 
      /** Authorization: `bearer ${this.key}`, */
    })
    
    return this.httpClient.get(`${this.APIUrl}/GetAllBidsByItemId/${itemId}`, { headers })
    
  }

  addBid(bid: any) : Observable<any>{
    return this.httpClient.post(`${this.APIUrl}`, bid)
    
  }

  constructor(private httpClient : HttpClient) { }
}
