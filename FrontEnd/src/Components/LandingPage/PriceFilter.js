import { fade, makeStyles } from "@material-ui/core/styles";
import InputBase from "@material-ui/core/InputBase";
import Typography from "@material-ui/core/Typography";
import { useState } from "react";

const useStyles = makeStyles((theme) => ({
    price: {
        position: 'relative',
        borderRadius: theme.shape.borderRadius,
        backgroundColor: fade(theme.palette.common.white, 0.15),
        '&:hover': {
          backgroundColor: fade(theme.palette.common.white, 0.25),
        },
        marginTop: 20,
        marginRight: 20,
        marginLeft: 20,
        width: '100%',
        [theme.breakpoints.up('md')]: {
          marginLeft: theme.spacing(20),
          marginRight: theme.spacing(20),
          width: 'auto',
        },
      },
      priceText: {
        padding: theme.spacing(0, 2),
        height: '100%',
        position: 'absolute',
        pointerEvents: 'none',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        color: 'grey'
      },
      inputRoot: {
        color: 'white',
      },
      inputInput: {
        padding: theme.spacing(1, 1, 1, 1),
        paddingLeft: `${theme.spacing(18)}px`,
        height: '100%',
        width: '20%',
        position: 'relative',
        alignItems: 'center',
        justifyContent: 'left',
      },
}));

export default function PriceFilter(props) {
    const classes = useStyles();

    const priceSerchMinHandler = (event) => {
        props.onChangeMinPrice(event.target.value);
    };

    const priceSerchMaxHandler = (event) => {
        props.onChangeMaxPrice(event.target.value);
    };

    return (
        <div className={classes.price}>
            <div className={classes.priceText}>
                <Typography
                    variant="body2"
                    align="center"
                >
                    PRICE RANGE : 
                </Typography>
            </div>

            <InputBase
                placeholder="Min…"
                classes={{
                    root: classes.inputRoot,
                    input: classes.inputInput,
                }}
                inputProps={{ "aria-label": "search" }}
                type="number"
                onChange={priceSerchMinHandler}
            />
            <InputBase
                placeholder="Max…"
                classes={{
                    root: classes.inputRoot,
                    input: classes.inputInput,
                }}
                inputProps={{ "aria-label": "search" }}
                type="number"
                onChange={priceSerchMaxHandler}
            />
        </div>
    );
}
