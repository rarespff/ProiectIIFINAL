import {Button, Row} from "react-bootstrap";
import productService from "../../../Services/ProductService";
import React, {useEffect, useState} from "react";
import stockService from "../../../Services/StockService";
import {Link} from "react-router-dom";
// import image from "../../../Pictures/IMG_E1111.JPG"
// import image from "../../../../public/"
function ProductCard(props){

    const [img,setImg]= useState("");
    const [price, setPrice] = useState("");
    const imageURL=process.env.PUBLIC_URL + "/" + props.photoUrl;
    // const fetchImage = async () => {
    //     const res = await fetch(props.photoUrl);
    //     const imageBlob = await res.blob();
    //     const imageObjectURL = URL.createObjectURL(imageBlob);
    //     setImg(imageObjectURL);
    //   };
    useEffect(() => {
        // import(props.photoUrl).then(image => console.log("Image : ",image));
        // setImageURL(require(`${ props.photoUrl }`));
        stockService.getSmallestPriceForProduct(props.productId).then(response => {
            setPrice(response);
        })
        // productService.getImageToShow(imageURL).then(response => {
        //     setImg(response);
        // })
    },[]);
    
    // console.log(props.productName);
    // console.log(props.productId);


    return (
        <div className="card">
          <div className="card-img">
              <img className="product-img" src={imageURL} alt={props.productName}/>
          </div>
            <div className="card-body">
                <Row>
                {props.productName}
                </Row>
                <Row>
                    {price + '$'}
                </Row>
                <Link
                    to="/ProductDetails"
                    state={{
                        productId: props.productId,
                        name : props.productName,
                        stocks : props.stocks,
                        photoUrl : props.photoUrl
                    }}
                >View Details</Link>
            </div>
        </div>
    );
}
export default ProductCard;