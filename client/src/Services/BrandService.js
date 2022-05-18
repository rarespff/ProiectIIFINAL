import axios from "axios";
import authHeader from "./auth-header";
const API_URL = "https://localhost:44367/api/Brands/";

class BrandService {
    getAllBrands() {
        return axios.get(API_URL + "GetAllBrands").then(response => {
            return response.data;
        });
    }

    getBrandById(id) {
        return axios.get(API_URL + "GetBrandById/" + id).then(response => {
            return response.data;
        });
    }

    addNewBrand(name) {
        return axios.post(API_URL + "AddBrand", {
            Name: name,
        }, { headers: authHeader() }).then(response => {
            return response.data;
        });
    }

    deleteBrandById(id) {
        return axios.delete(API_URL + "DeleteBrand/" + id, { headers: authHeader() }).then(response => {
            return response.data;
        });
    }

    editBrand(id, name) {
        return axios.post(API_URL + "edit", {
            id: id,
            name: name
        }, { headers: authHeader() }).then(response => {
            return response.data;
        });
    }
}
export default new BrandService();