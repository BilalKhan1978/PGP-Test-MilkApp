import MilkInfo from "./components/MilkInfo";
import {BrowserRouter,Route,Routes} from 'react-router-dom'
import MilkView from "./components/MilkView";


function App() {
  
  return (
    <div style={{backgroundColor: "#eed3d7" }}>
      <h3 style={{backgroundColor: "white",textAlign: "center",padding:"20px",fontFamily:"monospace",
      color:"#aa8c90",fontWeight:"bold"
  }}>THE MILK STORE</h3>
    <div  className="container">
    <BrowserRouter>
    <Routes>
      <Route path='/' element={<MilkInfo/>}></Route>      
      <Route path='/milkview/:milkid' element={<MilkView/>}></Route>      
    </Routes>
  </BrowserRouter> 
      </div>
      
    </div>
  );
}
export default App;

