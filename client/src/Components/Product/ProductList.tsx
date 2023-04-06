import {Box, Button, Container, Grid, Typography} from "@mui/material";
import TableContainer from "@mui/material/TableContainer";
import Paper from "@mui/material/Paper";
import Table from "@mui/material/Table";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import TableCell from "@mui/material/TableCell";
import TableBody from "@mui/material/TableBody";
import {Product} from "../../app/models/Product";
import agent from "../../app/api/agent";
import React, {useEffect} from "react";
import {Link, NavLink, Outlet} from "react-router-dom";


export default function ProductList(){
    const [products, setProducts] = React.useState<Product[]>([]);


    useEffect(() => {
        agent.Products.list().then(response => {
            setProducts(response);
        });
    },[])


    const onDelete = (id : string) => {
        agent.Products.delete(id)
            .then(r => {setProducts((prevState) =>
                prevState.filter((product) => product.id !== id)
            );});

    }
    
    
    return (
        <Container sx={{marginBottom: 15 }}>
            <Box display="flex" justifyContent="space-between" alignItems="center" marginBottom={3}>
                <Button variant="contained" color="primary" sx={{marginRight: 2}} component={Link} to='create'>Create new product</Button>
                <Typography variant="body1" 
                            sx={{ 
                                border: '1px solid blue',
                                borderRadius: '10px',
                                padding: '10px'}}
                >
                    Total products: {products.length ?? 0}
                </Typography>
            </Box>
            <Grid justifyContent="center">
                <Grid item >
                    <TableContainer component={Paper} >
                        <Table padding='normal' aria-label="simple table">
                            <TableHead>
                                <TableRow>
                                    <TableCell align='center'>Picture</TableCell>
                                    <TableCell align='center'>Name</TableCell>
                                    <TableCell align='center'>Price</TableCell>
                                    <TableCell align='center'>Abailable count</TableCell>
                                    <TableCell align='center'>Short description</TableCell>
                                    <TableCell align='center'>Category</TableCell>
                                    <TableCell align='center' >Options</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {products.map((product)  => (
                                    <TableRow
                                        key={product.id}
                                        sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                    >
                                        <TableCell component="th" scope="row" align='center'>
                                            {product.imageUrl}
                                        </TableCell>
                                        <TableCell component="th" scope="row" align='center'>
                                            {product.name}
                                        </TableCell>
                                        <TableCell component="th" scope="row" align='center'>
                                            {product.price} $
                                        </TableCell>
                                        <TableCell component="th" scope="row" align='center'>
                                            {product.availableCount} 
                                        </TableCell>
                                        <TableCell component="th" scope="row" align='center'>
                                            {product.shortDescription}
                                        </TableCell>
                                        <TableCell component="th" scope="row" align='center'> 
                                            {product.category.name}
                                        </TableCell>
                                        <TableCell component="th" align='center' scope="row">
                                            <Button variant="contained" color="primary" sx ={{marginRight: 2}} component={NavLink} to={`${product.id}`}>Edit</Button>
                                            <Button variant="contained" color='error' onClick={() => onDelete(product.id)}>Delete</Button>
                                        </TableCell>
                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Grid>
            </Grid>
        </Container>
    )
}