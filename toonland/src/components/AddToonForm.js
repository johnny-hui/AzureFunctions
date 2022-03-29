import React,{useState,useEffect} from 'react';
import { Navigate } from 'react-router-dom';


const AddToonForm =()=>{
  const [firstName,setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [occupation, setOccupation] = useState('');
  const [gender, setGender] = useState('');
  const [pictureUrl, setPictureUrl] = useState('');
  const [votes, setVotes] = useState(0);
  const [addFlag,setAddFlag] = useState(false);
  const [pictures,getPicture] = useState([]);

  const addToon =()=>{
      const result = fetch(`https://api4all.azurewebsites.net/api/people/`,{
          method:'post',
          body:JSON.stringify({
              firstName,
              lastName,
              occupation,
              gender,
              pictureUrl,
              votes
          }),
          headers:{'Content-Type':'application/json'}
      });
      setAddFlag(true);
  }

  const fetchPictures = async()=>{
      const r1 = await fetch(`https://api4all.azurewebsites.net/api/pictures`);
      const b1 = await r1.json();
      getPicture(b1);
  }

  useEffect(() => {
      fetchPictures();
  }, []);

  if(addFlag)
  {
      return <Navigate to={{pathname:"/list",state:{refresh:true}}}/>;
  }
  return(
  <React.Fragment>
  <div className="panel panel-default">
    <form>
      <h3>Add toon character</h3>
      <div className="form-group">
        <label>First Name:</label>
        <input className="form-control" type="text" placeholder="First Name"
          value={firstName} onChange={(event) => setFirstName(event.target.value)} />
      </div>
      <div className="form-group">
        <label>Last Name:</label>
        <input className="form-control" type="text" placeholder="Last Name"
          value={lastName} onChange={(event) => setLastName(event.target.value)} />
      </div>
      <div className="form-group">
        <label>Occupation:</label>
        <input className="form-control" type="text" placeholder="Occupation"
          value={occupation} onChange={(event) => setOccupation(event.target.value)} />
      </div>
      <div className="form-group">
        <label>Gender:</label>
        <input className="form-control" type="text" placeholder="Gender"
          value={gender} onChange={(event) => setGender(event.target.value)} />
      </div>
      <div className="form-group">
          <label>Picture URL:</label>
          <select className="form-control" value={pictureUrl} onChange={(event) => setPictureUrl(event.target.value)}>
              {
                  pictures.map(
                     (item,key)=>( <option key={key} value={item.url}>{item.name}</option>)
                  )
              }
          </select>
      </div>

      <input type="submit" onClick={() => addToon()} className="btn btn-success" value="Add" />
    </form>
  </div>
</React.Fragment>
);
}

export default AddToonForm;
