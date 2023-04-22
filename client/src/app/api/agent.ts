import { Category } from '../models/Category';
import { Product } from '../models/Product';
import axios, { AxiosResponse } from 'axios';

axios.defaults.baseURL = 'http://localhost:5223/api/v1';

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T>(url: string) => axios.delete<T>(url).then(responseBody),
}

const Categories = {
    get : (id: string) : Promise<Category> => requests.get<Category>(`/Category/${id}`),
    list: () : Promise<Category[]> => requests.get<Category[]>('/Category'),
    create: (category: Category) => requests.post('/Category', category),
    update: (category: Category) => requests.put(`/Category/${category.id}`, category),
    delete: (id: string)  => requests.delete(`/Category/${id}`)
}

const Products = {
    get : (id: string) : Promise<Product> => requests.get<Product>(`/Product/${id}`),
    list: () : Promise<Product[]> => requests.get<Product[]>('/Product'),
    create: (product: Product) => requests.post('/Product', product),
    update: (product: Product) => requests.put(`/Product/${product.id}`, product),
    delete: (id: string)  => requests.delete(`/Product/${id}`)
}


const agent = {
    Categories,
    Products
}

export default agent;