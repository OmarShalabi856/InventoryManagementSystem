using Microsoft.EntityFrameworkCore;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;

namespace InventoryManagementSystem.Services
{
    public class OpenAIService
    {
        private readonly ChatClient _chatClient;

        public OpenAIService()
        {
            var apiKey = Environment.GetEnvironmentVariable("OPEN_AI_KEY")
                ?? throw new ArgumentNullException("OPEN_AI_KEY", "OPEN AI KEY IS MISSING");

            var openAiClient = new OpenAIClient(apiKey);
            _chatClient = openAiClient.GetChatClient("gpt-3.5-turbo");
        }

        public async Task<string> ChatCompletion(string data, string prompt)
        {
            var chatMessages = new List<ChatMessage>
            {
                new SystemChatMessage("You are an inventory system assistant."),
                new SystemChatMessage($"This is the data provided to you to help assist the employee:\n{data}"),
                new UserChatMessage($"Based on the above inventory data, please answer the employee's question: {prompt}")
            };

            var response = await _chatClient.CompleteChatAsync(chatMessages, new ChatCompletionOptions
            {
                Temperature = 0.7f
            });

            return response.Value.Content[0].Text;
        }

    }
}
