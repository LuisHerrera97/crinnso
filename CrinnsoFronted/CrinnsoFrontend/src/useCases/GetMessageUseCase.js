import { MessageService } from "../services/messageService";

export class GetMessageUseCase {
    constructor() {
      this.messageService = new MessageService();
    }
  
    async execute() {
      return await this.messageService.getMessage();
    }
  }