import * as React from "react";
import Card from "@material-ui/core/Card";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";
import { CardMedia } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";
import SellRating from "./SellRating";

const useStyles = makeStyles((theme) => ({
    media: {
        position: "relative",
    },
    cardFrame: {
        marginTop: 20,
        marginRight: 20,
        marginLeft: 20,
        backgroundColor: "grey",
        borderWidth: 10,
        borderColor: "red",
        width: 200
    },
    buttonStyle: {
        background: "linear-gradient(45deg, #fe6b8b 30%, #ff8e53 90%)",
        marginLeft: 'auto',
        marginRight: 'auto',
        width: '100%',
        borderRadius: "10px",
    },
    offerStyle: {
        position: "absolute",
        right: 0,
        top: 0,
        zIndex: 1,
        color: "white",
    },
    container: {
        flexDirection: "row",
        flexWrap: "wrap",
        padding: 1,
    },
    cardContentStyle: {
        width: 'auto',
        marginLeft: 'auto',
        marginRight: 'auto',
    },
}));

export default function SellItem(props) {
    const classes = useStyles();
    return (
        <Card sx={{ minWidth: 275 }} className={classes.cardFrame}>
            <CardContent>
                <div className={classes.container}>
                    {(!(props.product.savings === "") && !(props.product.savings === undefined)) &&
                        <Typography variant="h5" component="div">
                            {props.product.savings.toFixed()}% Saving!
                        </Typography>
                    }
                    <CardMedia
                        component="img"
                        image={props.product.thumb}
                        alt="landingImage"
                        className={classes.media}
                    />
                </div>
                <div className={classes.cardContentStyle}>
                    <Typography
                        sx={{ fontSize: 14 }}
                        gutterBottom
                    >
                        {props.product.title}
                    </Typography>
                    <Typography variant="h5" component="div">
                        {props.product.steamRatingText}
                    </Typography>
                    <SellRating rate={props.product.dealRating/2}/>
                </div>
            </CardContent>
            <CardActions>
                <Button
                    variant="contained"
                    color="primary"
                    className={classes.buttonStyle}
                >
                     {(!(props.product.savings === "") && !(props.product.savings === undefined)) ? 
                            <div>
                            <Typography variant="h5" component="div" style={{textDecorationLine: 'line-through', textDecorationStyle: 'solid'}}>
                            {props.product.normalPrice}
                            </Typography>
                            <Typography variant="h5" component="div">
                            {props.product.salePrice}
                            </Typography>
                            </div>
                            :
                            <Typography variant="h5" component="div">
                            {props.product.normalPrice}  
                            </Typography>
                     } 

                </Button>
            </CardActions>
        </Card>
    );
}
