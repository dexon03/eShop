import { createBrowserRouter, RouteObject } from "react-router-dom";
import App from "../../App";
import About from "../../Components/About/About";
import CategoryList from "../../Components/Category/CategoryList";
import Contact from "../../Components/Contact/Contact";


export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            {
                path: 'category',
                element: <CategoryList />,
            },
            {
                path: 'contact',
                element: <Contact />,
            },
            {
                path: 'about',
                element: <About />,
            }
        ]
    }    
];

export const router = createBrowserRouter(routes);