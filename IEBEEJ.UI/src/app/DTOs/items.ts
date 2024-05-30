import { SmallBidDTO } from "./bids";

export interface ItemDTO {
    estimatedValueMax: number;
    estimatedValueMin: number;
    startingPrice: number;
    category: number;
    id: number;
    sellerId: number;
    sellerName: string;
    lastModified: Date;
    itemDescription: string;
    itemName: string;
    sendingAdress: string;
    created: Date;
    endDate: Date;
    smallBid: SmallBidDTO
}
