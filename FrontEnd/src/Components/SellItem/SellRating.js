import * as React from 'react';
import Box from '@material-ui/core/Box';
import Rating from '@material-ui/lab/Rating';

export default function BasicRating(props) {

  return (
    <Box
      sx={{
        '& > legend': { mt: 2 },
      }}
    >
      <Rating name="read-only" 
            value={props.rate} 
            precision={0.1}
            readOnly/>
    </Box>
  );
}