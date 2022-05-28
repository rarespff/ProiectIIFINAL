import axios from "axios";
import React from "react";
import FirstPage from "../Components/HomePage/FirstPage";
import { useHistory } from "react-router-dom"

const API_URL = "https://localhost:44367/api/Users/";

class AuthService {
    login(username, password) {
        return axios.post(API_URL + "Login", {
                username: username,
                password: password
            })
            .then(response => {
                localStorage.setItem("user", JSON.stringify(response.data));
                return response.data;
            });
    }

    logout() {
        localStorage.removeItem("user");
        return ( <
                FirstPage / >
            )
            // history.push("/");
    }

    getCurrentUser() {
        return JSON.parse(localStorage.getItem('user'));
    }

    register(email, username, password, firstname, lastname) {
        return axios.post(API_URL + "Register", {
            Email: email,
            Username: username,
            Password: password,
            FirstName: firstname,
            LastName: lastname
        }).then(response => {
            return response.data;
        })
    }
}

export default new AuthService();