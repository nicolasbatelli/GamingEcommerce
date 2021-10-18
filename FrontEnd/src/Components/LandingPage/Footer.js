import { makeStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';

const useStyles = makeStyles((theme) => ({
  footer: {
    padding: theme.spacing(1, 1),
    marginTop: '50px',
    backgroundColor:
      theme.palette.type === 'light' ? theme.palette.grey[200] : theme.palette.grey[800],
  },
}));

export default function Footer() {
  const classes = useStyles();

  return (
      <footer className={classes.footer}>
          <Typography variant="body2" color="textSecondary" align="center">
              Copyright © Nicolas Batelli - Gaming store {new Date().getFullYear()}
          </Typography>
      </footer>
  )
}
