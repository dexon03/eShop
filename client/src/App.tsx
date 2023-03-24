import './App.css';
import NavBar from './Components/NavBar';
import { Outlet } from 'react-router-dom';
import Container from '@mui/material/Container';
import { useEffect, useState } from 'react';
import agent from './app/api/agent';
import { Category } from './app/models/Category';
import CategoryList from './Components/Category/CategoryList';
import CreateCategory from './Components/Category/CreateCategory';

function App() {
  
  


  return (
      <>
        <NavBar />
        <Container style={{marginTop: '7em'}}>
          {/* <CreateCategory /> */}
          {/* <CategoryList /> */}
          <Outlet />
        </Container>
      </>
  );
}

export default App;
