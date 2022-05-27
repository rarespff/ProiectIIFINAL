import axios from "axios";
import authHeader from "./auth-header";
const API_URL = "https://localhost:44367/api/CartProducts/";

class CartService {
    addToCart(userId, productId, quantity, size) {
        console.log(userId);
        console.log(productId);
        console.log(quantity);
        console.log(size);
        return axios
            .post(API_URL + "AddProductToCart/" + userId, {
                ProductId: productId,
                Quantity: quantity,
                Size: size,
            })
            .then((response) => {
                return response.data;
            });
    }

    getCartSize(userId) {
        return axios.get(API_URL + "GetCartSize/" + userId).then((response) => {
            return response.data;
        });
    }

    getCartProducts(userId) {
        return axios
            .get(API_URL + "GetCartProductsByUserId/" + userId)
            .then((response) => {
                return response.data;
            });
    }

    removeFromCart(cartProductId) {
        return axios
            .delete(API_URL + "DeleteCartProduct/" + cartProductId)
            .then((response) => {
                return response.data;
            });
    }

    orderProducts(userId) {
        axios.post(API_URL + "OrderProducts/" + userId);
    }
}

export default new CartService();