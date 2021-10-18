import axios from "axios";

const baseURL = process.env.REACT_APP_BASEURL;

export default function GetProductGameSales(handler, query, errorHandler, loaderHandler)
{
    errorHandler(false);
    loaderHandler(true);
    axios
    .get(baseURL + query)
    .then((response) => {
        handler(response.data);
        loaderHandler(false);
    })
    .catch(() => {
        errorHandler(true);
        loaderHandler(false);
    });
};