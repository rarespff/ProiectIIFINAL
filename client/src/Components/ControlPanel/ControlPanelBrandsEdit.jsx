import {useNavigate} from "react-router-dom";
import React, {useEffect, useState} from "react";
import authService from "../../Services/AuthService";
import userService from "../../Services/UserService";
import Navigation from "../HomePage/Navigation";
import {Link} from "react-router-dom";
import {Container} from "@mui/material";
import FooterPage from "../HomePage/FooterPage";
import brandService from "../../Services/BrandService";
import {set} from "react-hook-form";

function ControlPanelBrandsEdit(){
    const navigate = useNavigate();
    const [brands,setBrands] = useState([]);
    useEffect(() => {
        if (!authService.getCurrentUser().admin===1) {
            navigate(-1);
        }
        brandService.getAllBrands().then(response => {
            setBrands(response);
            console.log(brands);
        });

    },[])

    return (
        <div className="mainContainer">
            <div className="upContainer">
                <div className="navbar">
                    <Navigation />
                </div>
            </div>
            <div>
                <Container className="table-container">
                    <table className="table table-striped table-bordered">
                        <thead>
                        <tr>
                            <th>Name</th>
                            <th>Action</th>
                        </tr>
                        </thead>
                        <tbody>
                        {brands && brands.map(brand =>
                            <tr key={brand.id}>
                                <td>{brand.name}</td>
                                <td>

                                    <Link
                                        to="/ControlPanelBrandsEditBrand"
                                        state={{
                                            id: brand.id,
                                            name: brand.name
                                        }}
                                    >Edit</Link>
                                </td>
                            </tr>
                        )}
                        </tbody>
                    </table>
                </Container>
            </div>
            <FooterPage/>
        </div>
    );

}

export default ControlPanelBrandsEdit;