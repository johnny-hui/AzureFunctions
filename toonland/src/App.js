import HomePage from './pages/HomePage';
import AboutPage from './pages/AboutPage';
import ToonListPage from './pages/ToonListPage';
import ToonDetailPage from './pages/ToonDetailPage';
import NotFoundPage from './pages/NotFoundPage';
import NavBar from './NavBar';
import 'bootstrap/dist/css/bootstrap.css';
import 'jquery/dist/jquery.min.js';
import 'popper.js/dist/umd/popper.min.js';
import 'bootstrap/dist/js/bootstrap.min.js';
import {
  BrowserRouter,
  Routes,
  Route
} from 'react-router-dom';



function App() {
  return (
    <div className="container">
      <BrowserRouter>
      <NavBar />
        <Routes>
          <Route path="/" element={<HomePage />} exact />
          <Route path="/about" element={<AboutPage />} exact />
          <Route path="/list" element={<ToonListPage />} exact />
          <Route path="/detail/:id" element={<ToonDetailPage />} exact />
          <Route path='*' element={NotFoundPage} />
        </Routes>
      </BrowserRouter>
    </div>

  );
}

export default App;
