import { useEffect, useMemo, useState } from "react";
import CssBaseline from "@material-ui/core/CssBaseline";
import Grid from "@material-ui/core/Grid";
import Container from "@material-ui/core/Container";
import Footer from "./Footer";
import Header from "./Header";
import { fade, makeStyles } from "@material-ui/core/styles";
import { Backdrop, Button, CardMedia, Typography } from "@material-ui/core";
import CircularProgress from "@material-ui/core/CircularProgress";
import SearchIcon from "@material-ui/icons/Search";
import InputBase from "@material-ui/core/InputBase";
import SellItem from "../SellItem/SellItem";
import PriceFilter from "./PriceFilter";
import Product from "../../models/product";
import ProductService from "../../services/Product.Service";
import { FlashOnRounded } from "@material-ui/icons";

const useStyles = makeStyles((theme) => ({
  root: {
    display: "flex",
    flexDirection: "column",
    minHeight: "100vh",
  },
  container: {
    marginBottom: theme.spacing(2),
  },
  footer: {
    padding: theme.spacing(3, 2),
    marginTop: "auto",
    backgroundColor:
      theme.palette.type === "light"
        ? theme.palette.grey[200]
        : theme.palette.grey[800],
  },
  backdrop: {
    zIndex: theme.zIndex.drawer + 1,
    color: "#fff",
  },
  search: {
    position: "relative",
    borderRadius: theme.shape.borderRadius,
    backgroundColor: fade(theme.palette.common.white, 0.15),
    "&:hover": {
      backgroundColor: fade(theme.palette.common.white, 0.25),
    },
    marginTop: 20,
    marginRight: 20,
    marginLeft: 20,
    width: "100%",
    [theme.breakpoints.up("md")]: {
      marginLeft: theme.spacing(20),
      marginRight: theme.spacing(20),
      width: "auto",
    },
  },
  searchIcon: {
    padding: theme.spacing(0, 2),
    height: "100%",
    position: "absolute",
    pointerEvents: "none",
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
    color: "grey",
  },
  inputRoot: {
    color: "grey",
  },
  inputInput: {
    padding: theme.spacing(1, 1, 1, 0),
    paddingLeft: `calc(1em + ${theme.spacing(4)}px)`,
    transition: theme.transitions.create("width"),
    width: "100%",
    [theme.breakpoints.up("sm")]: {
      width: "12ch",
      "&:focus": {
        width: "20ch",
      },
    },
  },
  media: {
    height: 300,
    paddingTop: "0%", // 16:9
  },
  gridStyle: {
    marginLeft: "auto",
    marginRight: "auto",
    marginTop: "1em",
    width: "16em",
    [theme.breakpoints.up("sm")]: {
      marginLeft: theme.spacing(5),
      marginRight: theme.spacing(5),
      width: "auto",
    },
  },
  buttonStyle: {
    background: "linear-gradient(45deg, #006b8b 30%, #ff8e53 90%)",
    borderRadius: "10px",
    marginLeft: "auto",
    marginRight: "auto",
    marginTop: "1em",
    width: "16em",
  },
  errorStyle: {
    marginLeft: "auto",
    marginRight: "auto",
    marginTop: "1em",
    width: "16em",
    color: "white",
  },
}));

export default function LandingPage() {
  const classes = useStyles();
  const [error, setError] = useState(false);
  const [inputText, setInputText] = useState("");
  const [minPrice, setMinPrice] = useState(0);
  const [maxPrice, setMaxPrice] = useState(0);
  const [isLoading, setIsLoading] = useState(true); // create Is Loading
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    ProductService(inputText, minPrice, maxPrice)
      .then((response) => {
        setProducts(response.data);
        setIsLoading(false);
      })
      .catch(() => {
        setError(true);
        setIsLoading(false);
      });
  }, []);

  const errorMessage = () => {
    return (
      <Typography variant="h5" component="div" className={classes.errorStyle}>
        An Error occured trying to get products, please try again later
      </Typography>
    );
  };

  const prevProduct = useMemo(
    () =>
      products && products.map((product) => (
        <SellItem key={product.gameID} product={product} />
      )),
    [products]
  );

  const handleSearch = (event: React.ChangeEvent<HTMLInputElement>) => {
    setInputText(event.target.value);
  };

  const minPriceChangeHandler = (value: number) => {
    setMinPrice(value);
  };

  const maxPriceChangeHandler = (value: number) => {
    setMaxPrice(value);
  };

  async function upDateSearchHandler() {
    setIsLoading(true);
    ProductService(inputText, minPrice, maxPrice)
    .then((response) => {
      setProducts(response.data);
      setError(false);
    })
    .catch(() => {
      setError(true);
    })
    .finally(() => {
      setIsLoading(false);
    });
  }

  return (
    <div className={classes.root}>
      <CssBaseline />
      <Header />
      <CardMedia
        className={classes.media}
        component="img"
        image="/Images/LandingPageImage.png"
        alt="landingImage"
      />
      <div className={classes.search}>
        <div className={classes.searchIcon}>
          <SearchIcon />
        </div>
        <InputBase
          placeholder="Search…"
          classes={{
            root: classes.inputRoot,
            input: classes.inputInput,
          }}
          inputProps={{ "aria-label": "search" }}
          onChange={handleSearch}
          value={inputText}
        />
      </div>
      <PriceFilter
        onChangeMinPrice={minPriceChangeHandler}
        onChangeMaxPrice={maxPriceChangeHandler}
      />
      <Button
        onClick={upDateSearchHandler}
        variant="contained"
        color="primary"
        className={classes.buttonStyle}
      >
        Search
      </Button>
      <Container component="main" maxWidth="lg" className={classes.container}>
        <main>
          <Grid container spacing={5} className={classes.gridStyle}>
            <>{error ? errorMessage() : prevProduct}</>
          </Grid>
        </main>
      </Container>
      <Footer />
      <Backdrop className={classes.backdrop} open={isLoading}>
        <CircularProgress color="inherit" />
      </Backdrop>
    </div>
  );
}
