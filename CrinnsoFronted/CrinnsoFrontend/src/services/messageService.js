import axios from "axios";
import { Message } from "../models/Message";
import { API_MENSAJE } from "../settings/apiConfig";

export class MessageService {
  async getMessage() {
    try {
      const response = await axios.get(API_MENSAJE);
      return new Message(response.data.result);
    } catch (error) {
      console.error("Error fetching message:", error);
      throw error;
    }
  }
}