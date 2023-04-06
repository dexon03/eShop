import {Link, useNavigate, useParams} from "react-router-dom";
import {Button, Container, FormControl, MenuItem, TextField} from "@mui/material";
import React, {useEffect} from "react";
import {Product} from "../../app/models/Product";
import agent from "../../app/api/agent";
import {v4 as uuidv4} from "uuid";
import {Category} from "../../app/models/Category";

export default function EditProduct() {
    
    const {id} = useParams();

    const navigate = useNavigate();
    const [categories, setCategories] = React.useState<Category[]>([]);
    const [product, setProduct] = React.useState<Product>({
        name: '',
        price: 0,
        availableCount: 0,
        description: '',
        shortDescription: '',
        categoryId: '',
        imageUrl: '',
    } as Product);
    
    
    useEffect(() => {
        if (id != null) {
            agent.Products.get(id).then((response) => {
                setProduct(response);
            });
        }
        agent.Categories.list().then((response) => {
            setCategories(response);
        });
    }, [])


    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        setProduct((prevState) => ({
            ...prevState,
            [name]: value,
        }));
    };

    const handleSubmit = (event : React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        product.price = parseFloat(product.price.toString());
        product.availableCount = parseInt(product.availableCount.toString());
        agent.Products.update(product).then(r => console.log(r));
        // console.log(product);
        navigate("/product");
    };
    
    return (
        <Container sx={{marginBottom: 50}}>
            <Button variant="contained" color="error" component={Link} to='/product' sx={{marginBottom: 4}}>Back to products</Button>
            <FormControl component="form" fullWidth={true} onSubmit={handleSubmit}>
                <TextField
                    name="name"
                    label="Name"
                    value={product.name}
                    onChange={handleChange}
                    required
                />
                <br />
                <TextField
                    name="price"
                    label="Price"
                    value={product.price}
                    helperText="It must be more than 0."
                    InputProps={{ inputProps: { min: 1 } }}
                    onChange={handleChange}
                    type="number"
                    required
                />
                <br />
                <TextField
                    name="availableCount"
                    label="Available Count"
                    value={product.availableCount}
                    InputProps={{ inputProps: { min: 0 } }}
                    helperText="It must be more than 0."
                    onChange={handleChange}
                    type="number"
                    required
                />
                <br />
                <TextField
                    name="description"
                    label="Description"
                    helperText="It must be at least 10 characters long."
                    InputProps={{ inputProps: { minLength: 10 } }}
                    value={product.description}
                    onChange={handleChange}
                    multiline
                    rows={4}
                    required
                />
                <br />
                <TextField
                    name="shortDescription"
                    label="Short Description"
                    helperText="It must be at least 5 characters long."
                    value={product.shortDescription}
                    InputProps={{ inputProps: { minLength: 5 } }}
                    onChange={handleChange}
                    multiline
                    rows={2}
                    required
                />
                <br />
                <TextField
                    select
                    required
                    label="Category"
                    name="categoryId"
                    value={product.categoryId}
                    onChange={handleChange}
                >
                    {categories.map((category) => (
                        <MenuItem key={category.name} value={category.id}>
                            {category.name}
                        </MenuItem>
                    ))}
                </TextField>
                <br />
                <TextField
                    name="imageUrl"
                    label="Picture URL"
                    value={product.imageUrl}
                    onChange={handleChange}
                />
                <br />
                <Button type="submit" variant="contained" color="primary">
                    Edit Product
                </Button>
            </FormControl>
        </Container>

    );
}