import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Milk } from "../types";
import Card from "./Card";
import SearchBar from "./SearchBar";
import { styles } from "./style";

const MilkInfo = () => {
 
  const [milkdata,milkdatachange]= useState<Milk[]>([]);
  
  const [selectedmilk,selectedmilkchange]= useState<Milk[]>([]);
  const navigate=useNavigate();
  const selectChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
  const value = event.target.value;
  
  selectedmilkchange(milkdata.filter(x=>x.type===value))
  };
  const showRecordDetails = (data: Milk) => {
    navigate('/milkview/'+data.id);
   // setRecordForEdit(data)
}

  
useEffect(() => {
    fetch('https://localhost:7171/api/Milk')    
    .then(response => response.json())
    .then((res:Milk[]) =>{milkdatachange(res);
                          selectedmilkchange(res);
    })
    .catch(err => console.log(err))
  },[])

  const imageCard = (data: Milk) => (
    <div className="card" onClick={() => { showRecordDetails(data) }}>
        <img src='/img/milk.png' className="card-img-top" />
    <div className="card-body">
            <h5>{data.name}</h5>
            <br/>
      <div className="row">
      <div className="col-md-6">
      <h6>{data.type}</h6> 
      </div>
      
      <div className="col-md-6">
      <h6 className="float-right">{data.storage} litre</h6>
      </div>
      </div>          
                
    </div>
    </div>
)

  return (
    <div>
        
     {/* dropdown */}
    <div style={styles.container}>
      <div className="row">
        <div className="col-md-6">
        <SearchBar/>
        </div>
        <div className="col-md-6">
        <select onChange={selectChange} style={styles.select} className="float-right">
        <option selected disabled>
        Choose one
        </option>
        <option value="Cashew milk">Cashew milk</option>
        <option value="Pea milk">Pea milk</option>
        <option value="Walnut milk">Walnut milk</option>
        <option value="Rice milk">Rice milk</option>
        <option value="Coconut milk">Coconut milk</option>
        <option value="Soy milk">Soy milk</option>
        <option value="Hemp milk">Hemp milk</option>
        <option value="Almond milk">Almond milk</option>
        <option value="Oat milk">Oat milk</option>
      
      </select>
        </div>
      </div>
    
   
      <br/>
      </div> 

        {/* Card section */}
        <div className="col-md-12">
                <table>
                    <tbody>
                        {
                            //tr > 3 td
                            [...Array(Math.ceil(selectedmilk.length / 3))].map((e, i) =>
                                <tr key={i}>
                                    <td>{imageCard(selectedmilk[3 * i])}</td>
                                    <td>{selectedmilk[3 * i + 1] ? imageCard(selectedmilk[3 * i + 1]) : null}</td>
                                    <td>{selectedmilk[3 * i + 2] ? imageCard(selectedmilk[3 * i + 2]) : null}</td>
                                </tr>
                            )
                        }
                    </tbody>
                </table>
            </div>
      {/* { selectedmilk && selectedmilk.map(item=>(
      
    <div>
      <section className="card-container">
      {(<Card
          id={item.id}
          name={item.name}
          type= {item.type}
          storage={item.storage}
           />)}
          <br/>      
         
      </section>
    </div> ))} */}
    </div>
  );
};

export default MilkInfo;
