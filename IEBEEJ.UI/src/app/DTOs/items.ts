import { SmallBidDTO } from "./bids";

export interface ItemDTO {
    allBids: SmallBidDTO[];
    categoryName: string;
    created: Date;
    endDate: Date;
    estimatedValueMax: number;
    estimatedValueMin: number;
    id: number;
    itemDescription: string;
    itemName: string;
    lastModified: Date;
    sellerId: number;
    sellerName: string;
    sendingAdress: string;
    startingPrice: number;
    highestBidPrice: number | undefined;
}

export interface AddItemDTO {
    startingPrice: number;
    category: number;
    sellerId: number;
    sellerName: string;
    itemDescription: string;
    itemName: string;
    sendingAddress: string;
    created: Date;
    endDate: Date;
}

export interface SmallItemDTO {
    id: number;
    itemName: string;
}

export interface UpdateItemDTO {
    estimatedValueMax: number;
    estimatedValueMin: number;
    startingPrice: number;
    category: number;
    id: number;
    sellerID: number;
    itemDescription: string;
    itemName: string;
    sendingAddress: string;
}