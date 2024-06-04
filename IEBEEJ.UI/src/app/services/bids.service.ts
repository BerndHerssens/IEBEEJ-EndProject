import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SmallBidDTO } from '../DTOs/bids';

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

  getHighestBid(bids : SmallBidDTO[]) : SmallBidDTO | null {
    console.log(bids);
    
    if (bids.length == 0) {
      return null
    } else {
    return bids.sort((a, b) => {
      if (a.bidValue > b.bidValue) {
          return -1;
      }
      if (a.bidValue < b.bidValue) {
          return 1;
      }
      return 0;
  })[0]}
}


  constructor(private httpClient : HttpClient) { }
}
