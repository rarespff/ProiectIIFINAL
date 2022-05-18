import axios from "axios";
import { UserContext } from "../../HomePage/User/UserContext";
import {useContext} from "react";
import Navigation from "../../HomePage/Navigation";

function Admin(){
    const [user]=useContext(UserContext);

    return(
        <div>   
            <Navigation/>
            <p> Here you can edit the BRANDS and PRODUCTS</p>
        </div>
    )
}

export default Admin;