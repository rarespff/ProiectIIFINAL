import axios from "axios";
import authHeader from "./auth-header";
const API_URL = "https://localhost:44367/api/Stocks/";

class StockService {

    addStockToProduct(productId, size, price, quantity, featured) {
        return axios.post(API_URL + "AddStockToProduct", {
            productId: productId,
            size: size,
            price: price,
            quantity: quantity
        }).then(response => {
            return response.data;
        });
    }

    editStock(stockId, productId, size, price, quantity, isFeatured) {
        console.log(stockId, productId, size, price, quantity, isFeatured);
        return axios.post(API_URL + "EditStock", {
            Id: stockId,
            productId: productId,
            size: size,
            price: price,
            quantity: quantity,
        }).then(response => {
            return response.data;
        })
    }

    deleteStockOfProduct(productName, size) {
        return axios.delete(API_URL + "DeleteStock/" + productName + "/" + size).then(response => {
            return response.data;
        });
    }

    getSmallestPriceForProduct(productId) {
        return axios.get(API_URL + "GetSmallestPrice/" + productId).then(response => {
            return response.data;
        })
    }

    getAllStockEntries() {
        return axios.get(API_URL + "GetAllStocks").then(response => {
            return response.data;
        })
    }
}

export default new StockService();