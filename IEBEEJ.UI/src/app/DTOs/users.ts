import { SmallBidDTO } from "./bids";
import { SmallItemDTO } from "./items";
import { SmallOrderDTO } from "./orders";

export interface UserDTO {
    id: number;
    name: string;
    email: string;
    password: string;
    address: string;
    bids: SmallBidDTO[];
    itemsForSale: SmallItemDTO[];
    boughtItems: SmallOrderDTO[];
    likedUsers: SmallUserDTO[];
    phoneNumber: string;
    birthday: Date;
}

export interface AddUserDTO {
    id: number;
    name: string;
    email: string;
    password: string;
    address: string;
    phoneNumber: string;
    birthday: Date;
}

export interface SmallUserDTO {
    id: number;
    name: string;
}

export interface UpdateUserDTO {
    name: string;
    email: string;
    password: string;
    address: string;
    phoneNumber: string;
    birthday: Date;
}
