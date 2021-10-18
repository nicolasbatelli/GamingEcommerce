import axios from "axios";
import Product from "../models/product";

const baseURL = process.env.REACT_APP_BASEURL;

export default function getProductGameSales(
  inputText: string,
  minPrice: number,
  maxPrice: number
): Promise<any> {
  return axios.get(`${baseURL}`, {
    params: {
      q: `${inputText ? "title : " + inputText : ""}${minPrice ? ",salePrice < " + minPrice.toString() : ""}${maxPrice ? ",salePrice > " + maxPrice.toString() : ""}`,
    },
  });
}
