import { Box, Typography, useTheme } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import { tokens } from "../../theme";
import { mockDataTeam } from "../../data/mockData";
import Header from "../../components/Header";
import axios from "axios";
import React, { useEffect, useState } from 'react';

const PortfolioComponents = () => {
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const columns = [
    {
      field: "id",
      headerName: "Id",
      type: "number",
      headerAlign: "left",
      align: "left",
    },
    {
      field: "name",
      headerName: "Name",
      flex: 1,
      cellClassName: "name-column--cell",
    },
    {
      field: "description",
      headerName: "Description",
      headerAlign: "left",
      align: "left",
    },
    {
      field: "userId",
      headerName: "UserId",
      type: "number",
      headerAlign: "left",
      align: "left",
    },  
  ];
  const url = "https://localhost:49157/api/Portfolio";
  const [userData, setUserData] = useState({});
  const getPortfolioComponents = async () => {
    const response = await axios.get(url);
    setUserData(response.data.data);
  };

  useEffect(() => {
    getPortfolioComponents();
  }, []);

  return (
    <Box m="20px">
      <Header title="Portfolio" subtitle="Managing the Portfolio Components" />
      <Box
        m="40px 0 0 0"
        height="75vh"
        sx={{
          "& .MuiDataGrid-root": {
            border: "none",
          },
          "& .MuiDataGrid-cell": {
            borderBottom: "none",
          },
          "& .name-column--cell": {
            color: colors.greenAccent[300],
          },
          "& .MuiDataGrid-columnHeaders": {
            backgroundColor: colors.blueAccent[700],
            borderBottom: "none",
          },
          "& .MuiDataGrid-virtualScroller": {
            backgroundColor: colors.primary[400],
          },
          "& .MuiDataGrid-footerContainer": {
            borderTop: "none",
            backgroundColor: colors.blueAccent[700],
          },
          "& .MuiCheckbox-root": {
            color: `${colors.greenAccent[200]} !important`,
          },
        }}
      >
        <DataGrid  rows={userData} columns={columns} />
      </Box>
    </Box>
  );
};

export default PortfolioComponents;