import { FormControl, InputLabel, Input, Button } from "@mui/material";
import { ChangeEvent, useState } from "react";
import { Category } from "../../app/models/Category";
import { v4 as uuidv4 } from 'uuid';
import agent from "../../app/api/agent";

export default function CreateCategory(){

    const category : Category = {
        id: "",
        name: ""
    }
    const [name, setName] = useState<string>('');

    const handleNameChange = (event: ChangeEvent<HTMLInputElement>) => {
        setName(event.target.value);
    };

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        category.id = uuidv4();
        category.name = name;
        agent.Categories.create(category);
    };

    return (
        <FormControl component="form" onSubmit={handleSubmit}>
        <InputLabel htmlFor="category-name">Category name</InputLabel>
        <Input
            id="category-name"
            aria-describedby="my-helper-text"
            required={true}
            value={name}
            onChange={handleNameChange}
        />
        <Button
            type="submit"
            variant="contained"
            color="primary"
            style={{ marginTop: '1em' }}
        >
            Create Category
        </Button>
        </FormControl>
    );
};