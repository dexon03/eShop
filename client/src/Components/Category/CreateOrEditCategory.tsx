import { FormControl, InputLabel, Input, Button } from "@mui/material";
import React, {ChangeEvent, Dispatch, SetStateAction, useEffect, useState} from "react";
import { Category } from "../../app/models/Category";
import { v4 as uuidv4 } from 'uuid';
import agent from "../../app/api/agent";


interface Props {
    isEdit : boolean,
    category : Category,
    setCategory : Dispatch<SetStateAction<Category>>
    setEdit : Dispatch<SetStateAction<boolean>>
}
export default function CreateOrEditCategory({isEdit,category, setCategory, setEdit} : Props){
    
    const [name, setName] = useState<string>('');

    const handleNameChange = (event: ChangeEvent<HTMLInputElement>) => {
        setName(event.target.value);
    };

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        category.id = category.id === '' ? uuidv4() : category.id;
        category.name = name;
        
        isEdit ? agent.Categories.update(category) : agent.Categories.create(category);
        
        setCategory({id: '', name : ''} as Category);
        setEdit(false);
    };

    useEffect(() => {
        setName(category.name)
    },[category]);
    
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
            { isEdit ? 'Edit category' : "Create Category"}
        </Button>
        </FormControl>
    );
};