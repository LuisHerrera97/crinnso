import React, { useState } from "react";
import { useMessageComponent } from "./useMessageComponent";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import Alert from "@mui/material/Alert";
import IconButton from "@mui/material/IconButton";
import CloseIcon from "@mui/icons-material/Close";

export const MessageComponent = () => {

    const {
        message,
        error,
        handleCloseMessage,
        handleCloseError,
        handleGetMessage
    } = useMessageComponent();
    return (
        <Container maxWidth="sm" style={{ marginTop: "50px", textAlign: "center" }}>
        <Typography variant="h3" gutterBottom>
            Crinnso
        </Typography>
        <Button
            variant="contained"
            color="primary"
            onClick={handleGetMessage}
            style={{ marginTop: "20px" }}
        >
            Obtener Mensaje
        </Button>
        {message && (
            <Alert
            severity="success"
            style={{ marginTop: "20px" }}
            action={
                <IconButton
                aria-label="close"
                color="inherit"
                size="small"
                onClick={handleCloseMessage}
                >
                <CloseIcon fontSize="inherit" />
                </IconButton>
            }
            >
            <Typography variant="body1">{message}</Typography>
            </Alert>
        )}
        {error && (
            <Alert
            severity="error"
            style={{ marginTop: "20px" }}
            action={
                <IconButton
                aria-label="close"
                color="inherit"
                size="small"
                onClick={handleCloseError}
                >
                <CloseIcon fontSize="inherit" />
                </IconButton>
            }
            >
            <Typography variant="body1">{error}</Typography>
            </Alert>
        )}
        </Container>
    );
};