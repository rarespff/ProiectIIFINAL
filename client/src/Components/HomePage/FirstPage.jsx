import React, {useEffect, useState} from "react";
import logo from "../../Pictures/logo.png";
import Navigation from "./Navigation";
import Slideshow from "./Slideshow.jsx";
import "../../Styles/styles.css";
import FooterPage from "./FooterPage";
import {Container, Divider} from "@mui/material";
import {Col, Row} from "react-bootstrap";
import productService from "../../Services/ProductService";
import ProductCard from "./components/ProductCard";
import stockService from "../../Services/StockService";



function FirstPage() {


    return (
        <>
            <Navigation/>
            <Row className="mw-inh">
                <Container className="mt-80">
                    <Container className="home-container">
                        <Row>
                            <Col>
                                <Slideshow/>
                            </Col>

                        </Row>
                    </Container>
                </Container>
            </Row>
            <FooterPage/></>
    )
}

export default FirstPage;
