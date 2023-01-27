import { Milk } from "../types"
import styles from './Card.module.css'

const Card = ({id,name,type,storage}: Milk) => {
  return (
    <div className={`stack-lg ${styles.card}`}>
         
        
        <img src='/img/milk.png' className={styles.image} />
      
      <div className="stack-sm">
        <p>{name}</p>
        
      </div>
      <div className="row">
      <div className="col-md-6">
      <span>{type}</span> 
      </div>
      <div className="col-md-4">
      <span className="float-right">{storage}</span>
      </div>
      </div>
      
       
     
    </div>
  )
}
export default Card