import { Paper, TextField } from '@mui/material';
import { makeStyles } from '@mui/styles'
import { tokens } from "../../theme";
import React, { useEffect, useState } from 'react';
import { Grid, FormControl, Radio, RadioGroup, FormControlLabel, FormLabel } from '@mui/material';
import { Box, Typography, useTheme } from "@mui/material";

const PortfolioComponentsForm = () => {

    const theme = useTheme();
    const colors = tokens(theme.palette.mode);

    const initialValues = {
        id: 0,
        fullName: '',
        ticker: '',
        type: '',
        amount: 0,
        price: 0.00,
    }

    const [values, setValues] = useState(initialValues);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setValues({
            ...values,
            [name]: value,
        });
    };


    return (
        <Box sx={{justifyContent: 'space-between'}}>
            <form >
                <Box sx={{ padding: 4, width: '90%', justifyContent: 'space-between', margin: '50px' }}>
                    <Grid container xs={8}>
                        <Grid container xs={8}>
                            <TextField
                                id="fullname-input"
                                name="fullName"
                                variant='outlined'
                                color="warning"
                                label='Full name'
                                value={values.fullName}
                                onChange={handleInputChange} />
                        </Grid>

                        <Grid container xs={8}>
                            <TextField
                                id="ticker-input"
                                name="ticker"
                                variant='outlined'
                                label='Ticker'
                                value={values.ticker}
                                onChange={handleInputChange} />
                        </Grid>
                        <Grid container xs={8}>
                            <FormControl>
                                <FormLabel>Type</FormLabel>
                                <RadioGroup
                                    name="type"
                                    value={values.type}
                                    onChange={handleInputChange}
                                    row
                                >
                                    <FormControlLabel
                                        key="share"
                                        value="share"
                                        control={<Radio size="small" />}
                                        label="Share"
                                    />
                                    <FormControlLabel
                                        key="bonds"
                                        value="bonds"
                                        control={<Radio size="small" />}
                                        label="Bonds"
                                    />
                                </RadioGroup>
                            </FormControl>
                        </Grid>
                        <TextField
                            id="amount-input"
                            name="amount"
                            label="Amount"
                            type="number"
                            value={values.amount}
                            onChange={handleInputChange}
                        />
                        <TextField
                            id="price-input"
                            name="price"
                            label="Price"
                            type="number"
                            value={values.price}
                            onChange={handleInputChange}
                        />
                    </Grid>
                </Box>
            </form>
        </Box>
    );
};

export default PortfolioComponentsForm;