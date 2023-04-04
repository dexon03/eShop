import { createBrowserRouter, RouteObject } from "react-router-dom";
import App from "../../App";
import About from "../../Components/About/About";
import CategoryList from "../../Components/Category/CategoryList";
import Contact from "../../Components/Contact/Contact";
import ProductList from "../../Components/Product/ProductList";
import React from "react";
import CreateProduct from "../../Components/Product/CreateProduct";


export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            {
                path: 'product',
                element: <ProductList />,
            },
            {
                path: 'category',
                element: <CategoryList/>,
            },
            {
                path: 'contact',
                element: <Contact />,
            },
            {
                path: 'about',
                element: <About />,
            },
            {
                path: 'product/create',
                element: <CreateProduct />,
            }
        ]
    }    
];

export const router = createBrowserRouter(routes);