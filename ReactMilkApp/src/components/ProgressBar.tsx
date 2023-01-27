const ProgressBar = (props: { bgcolor: any; completed: any; }) => {
    const { bgcolor, completed } = props;
  
    const containerStyles = {
      height: 10,
      width: '30%',
      backgroundColor: "#e0e0de",
      borderRadius: 50,
      margin:3
      
    }
  
    const fillerStyles = {
      height: '100%',
      width: `${completed}%`,
      backgroundColor: bgcolor,
      borderRadius: 'inherit'
      
    }
  
    const labelStyles = {
      padding: 5,
      color: 'white',
      fontWeight: 'bold'
    }
  
    return (
      <div style={containerStyles}>
        <div style={fillerStyles}>
          <span style={labelStyles}></span>
        </div>
      </div>
    );
  };
  
  export default ProgressBar;