import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "https://localhost:44367/api/Products/";

class ProductService {

    getAllProducts() {
        return axios.get(API_URL + "Available").then(response => {
            return response.data;
        });
    }

    getAllProductsWithoutStock() {
        return axios.get(API_URL + "AllProducts").then(response => {
            return response.data;
        });
    }

    // getProductsOnSale() {
    //     return axios.get(API_URL + "featured").then(response => {
    //         console.log(response.data);
    //         return response.data.map((item) => {
    //             return {
    //                 "id": item.id,
    //                 "name": item.name,
    //                 "photoUrl": item.photoUrl,
    //                 "stockDTOS": item.stockDTOS
    //             }
    //         });
    //     });
    // }

    getProductById(id) {
        return axios.get(API_URL + "ProductById/" + id).then(response => {
            return response.data;
        });
    }

    addNewProduct(name, category, brand, encodedPhoto) {
        const formData = new FormData();
        formData.append("name", name);
        formData.append("categoryName", category);
        formData.append("brandName", brand);
        formData.append("photoUrl", encodedPhoto);
        return axios.post(API_URL + "AddProduct",
            formData).then(response => {
            return response.data;
        });
    }

    editProduct(id, name, category, brand, encodedPhoto) {
        const formData = new FormData();
        formData.append("id", id);
        formData.append("name", name);
        formData.append("categoryName", category);
        formData.append("brandName", brand);
        if (encodedPhoto) {
            formData.append("photoUrl", encodedPhoto);
        }
        return axios.post(API_URL + "edit",
            formData, { headers: authHeader() }).then(response => {
            return response.data;
        });
    }

    getAllSportProducts() {
        return axios.get(API_URL + "SportProducts").then(response => {
            return response.data;
        })
    }

    getPhotoProduct(path) {
        return axios.get(API_URL + "photo", {
            params: {
                path: path
            }
        }).then(response => {
            return response.data;
        });
    }

    getAllCasualProducts() {
        return axios.get(API_URL + "CasualProducts").then(response => {
            return response.data;
        })
    }

    getAllElegantProducts() {
        return axios.get(API_URL + "ElegantProducts").then(response => {
            return response.data;
        })
    }

    deleteById(id) {
        return axios.delete(API_URL + "Delete/" + id).then(response => {
            return response.data;
        })
    }
}

export default new ProductService();