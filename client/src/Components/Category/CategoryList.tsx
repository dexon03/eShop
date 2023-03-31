import { useEffect, useState } from "react";
import agent from "../../app/api/agent";
import * as React from 'react';

import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import {Category} from "../../app/models/Category";
import {Button, Grid} from "@mui/material";
import CreateOrEditCategory from "./CreateOrEditCategory";



export default function CategoryList(){
    
    const [categories, setCategories] = useState<Category[]>([]);
    const [isEdit, setEdit] = useState<boolean>(false);
    const [category, setCategory] = useState<Category>({id: '', name : ''} as Category);


    useEffect(() => {
        agent.Categories.list().then(response => {
            setCategories(response);
        })
        setCategory({id: '', name : ''} as Category);
    },[]);
    
    const handleDelete = (id: string) => {
        agent.Categories.delete(id)
            .then(r => {setCategories((prevState) =>
                prevState.filter((category) => category.id !== id)
            );});
        
    }
    const handleEdit = (category: Category) => {
        setCategory(category);
        setEdit(true);
    }
    
    return (
        <Grid 
            container
            direction="row"
            justifyContent="center"
            spacing={10}>
            <Grid item >
                <TableContainer component={Paper} sx={{width : 500}}>
                    <Table padding='normal' aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell align='center'>Name</TableCell>
                                <TableCell align='center' sx={{width:200}}>Options</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {categories.map((category)  => (
                                <TableRow
                                    key={category.id}
                                    sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                >
                                    <TableCell component="th" scope="row">
                                        {category.name}
                                    </TableCell>
                                    <TableCell align='center' >
                                        <Button variant="contained" color="primary" sx ={{marginRight: 2}} onClick = {() => handleEdit(category)}>Edit</Button>
                                        <Button variant="contained" color='error' onClick={() => handleDelete(category.id)}>Delete</Button>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </Grid>
            <Grid item>
                <CreateOrEditCategory isEdit = {isEdit} category={category} setCategory = {setCategory} setEdit ={setEdit}  />
            </Grid>
        </Grid>
    )
}