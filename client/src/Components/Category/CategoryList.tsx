import {List, ListItem, ListItemText} from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import agent from "../../app/api/agent";
import { Category } from "../../app/models/Category";




export default function CategoryList(){
    
    const [categories, setCategories] = useState<Category[]>([]);
    

    useEffect(() => {
        agent.Categories.list().then(response => {
            setCategories(response);
        })
    },[]);
    return (
        <List>
            {categories.map((category : Category) => (
                <ListItem key={category.id}>
                    <ListItemText primary={category.name} />
                </ListItem>
            ))}
        </List>
    )
}