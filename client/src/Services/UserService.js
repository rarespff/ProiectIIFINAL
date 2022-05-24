import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "https://localhost:44367/api/Users/";

class UserService {
    getAllUsers() {
        return axios.get(API_URL + "GetAllUsers").then(response => {
            return response.data;
        });
    }

    deleteUserById(id) {
        return axios.delete(API_URL + "DeleteUser/" + id).then(response => {
            return response.data;
        });
    }

    editUser(id, firstName, lastName, email) {
        return axios.post(API_URL + "EditUser", {
            id: id,
            firstName: firstName,
            lastName: lastName,
            email: email
        }).then(response => {
            return response.data;
        });
    }

}

export default new UserService();