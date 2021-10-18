import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import { makeStyles } from "@material-ui/core/styles";
import { Link } from "react-router-dom";
import Button from "@material-ui/core/Button";
import HomeIcon from "@material-ui/icons/Home";
import { CardMedia } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
    root: {
        marginBottom: "1%",
    },
    title: {
        flexGrow: 1,
        display: "none",
        [theme.breakpoints.up("sm")]: {
            display: "block",
        },
    },
    homeButton: {
        color: "white",
    },
    list: {
        width: 250,
    },
    fullList: {
        width: "auto",
    },
    paper: {
        padding: theme.spacing(2),
        textAlign: "center",
        color: theme.palette.text.secondary,
        flex: "1 0 auto",
        margin: theme.spacing(1),
    },
    media: {
      marginTop: 10,
      height: '40px',
      width: '50px'
    }
}));

const Header = () => {
    const classes = useStyles();

    return (
        <div className={classes.root}>
            <AppBar position="static" style={{ backgroundColor: "#111111" }}>
                <Toolbar>
                    <div className={classes.title}>
                        <Link to="/">
                            <Button
                                startIcon={
                                    <HomeIcon className={classes.homeButton} />
                                }
                            />
                        </Link>
                    </div>
                    <div className={classes.title}>Game Commerce</div>
                    <div>
                    <CardMedia
                                component="img"
                                image="/Images/Logo.png"
                                alt="landingImage"
                                className={classes.media}
                            />
                    </div>
                </Toolbar>
            </AppBar>
        </div>
    );
};

export default Header;
