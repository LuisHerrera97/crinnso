import { useState } from "react";
import { GetMessageUseCase } from "../../useCases/GetMessageUseCase";

export const useMessageComponent = () => {

    const [message, setMessage] = useState("");
    const [error, setError] = useState("");

    const handleCloseMessage = () => {
        setMessage("");
    };

    const handleCloseError = () => {
        setError("");
    };

    const handleGetMessage = async () => {
        const useCase = new GetMessageUseCase();
        try {
            const response = await useCase.execute();
            setMessage(response.text);
            setError("");
        } catch (error) {
            setError("Error al obtener el mensaje. Por favor, inténtalo de nuevo.");
            console.error("Error:", error);
        }
    };
    return { 
        message,
        error,
        handleCloseMessage,
        handleCloseError,
        handleGetMessage
    }
}