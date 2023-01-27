import { hover } from '@testing-library/user-event/dist/hover';
import React, {useState} from 'react'
import { useNavigate } from 'react-router-dom';
import { Milk } from '../types';


const SearchBar = () => {

 const [searchInput, setSearchInput] = useState("");
 const [searchdata,searchdatachange]= useState<Milk[]>([]);
 const navigate=useNavigate();
const handleChange = (e:any) => {
  e.preventDefault();
  setSearchInput(e.target.value);
};

if (searchInput.length > 3) {
    fetch('https://localhost:7171/api/Milk/search/'+searchInput)    
    .then(response => response.json())
    .then((res:Milk[]) =>{searchdatachange(res);                          
    })
    .catch(err => console.log(err))    
}
const showRecordDetails = (data: Milk) => {
    navigate('/milkview/'+data.id);
   // setRecordForEdit(data)
}
return <div>
<div>
    
<input
   type="search"
   className='icon'
   placeholder="Search"
   onChange={handleChange}
   value={searchInput} />  
</div>
{searchdata.length>0 &&(
<table>
  <tr>
    <th>Name</th>
    <th>Type</th>
  </tr>
  
{searchdata &&  searchdata.map(item=>(

<div>
  <tr onClick={() => { showRecordDetails(item) }} style={{cursor: 'pointer'}}>
    <td >{item.name}</td>
    <td>{item.type}</td>
  </tr>
</div>

))}
</table>
)}
</div>


};

export default SearchBar;