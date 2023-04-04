import {Category} from "./Category";

export interface Product {
    id: string,
    name: string,
    price: number,
    availableCount: number,
    description: string,
    shortDescription: string,
    categoryId: string,
    category: Category,
    imageUrl: string
}