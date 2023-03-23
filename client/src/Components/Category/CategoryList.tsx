import {List, ListItem, ListItemText} from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { Category } from "../../app/models/Category";




export default function CategoryList(){
    
    const [categories, setCategories] = useState<Category[]>([]);
    

    useEffect(() => {
        axios.get<Category[]>('http://localhost:5223/api/v1/category')
        .then(response => {
            setCategories(response.data);
        })
    }, []);
    return (
        <List>
            {categories.map((category : Category) => (
            <ListItem key={category.Id}>
                <ListItemText primary={category.Name} />
            </ListItem>
            ))}
        </List>
    )
}