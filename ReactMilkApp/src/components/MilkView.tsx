import { useEffect, useState } from "react";
import { useParams} from "react-router-dom";
import { Milk } from "../types";
import ProgressBar from "./ProgressBar";


// call two methods one is Get by Id
// second method is for updating a contact. PUT method

const MilkView = () =>{
    const { milkid } = useParams();
    const [milkdata,milkdatachange]= useState<Milk>();
    
    useEffect(() => {
      //api get by id endpoint url   
      document.body.style.backgroundColor = '#eed3d7'
      fetch("https://localhost:7171/api/Milk/" + milkid).then((res) => {
            return res.json();
        }).then((resp:Milk) => { milkdatachange(resp);       
           
        }).catch((err) => {
            console.log(err.message);
        })
    },[milkid]);

    const imageCard = () => (
        <div className="card" >
            <img src='/img/milk.png' className="card-img-top" />
        
        </div>
    )
    
    return(
        <div className="container">
         <a href="/"> Back</a>
         <br/>
         <br/>
         <div className="row">
            <div className="col-md-4">
            {imageCard()}
            </div>
            <div className="col-md-8">
            <br/>
            <span style={{color: "black" }}>{milkdata?.name}</span>
            <br/>
            <span style={{color: "gray" }}>{milkdata?.type}</span>
            <br/>
            <span style={{color: "#b4b49d" }}>{milkdata?.storage} litre</span>
            <br/>
            <br/>
            <br/>
            <ProgressBar key={milkdata?.id} bgcolor="lightgreen" completed={milkdata?.storage} />
            <br/>
            <br/>
            <button>Order</button>
            </div>
            
         </div>
    </div>
    )
    }
    
    export default MilkView;