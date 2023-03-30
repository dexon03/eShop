import './App.css';
import NavBar from './Components/NavBar';
import { Outlet } from 'react-router-dom';
import Container from '@mui/material/Container';
function App() {


  return (
      <>
        <NavBar />
        <Container style={{marginTop: '7em'}}>
          <Outlet />
        </Container>
      </>
  );
}

export default App;
