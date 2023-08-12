using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace OpenAI
{
    public class ChatGpt : MonoBehaviour
    {
        private OpenAIApi openai = new OpenAIApi("enter");
        private List<ChatMessage> messages = new List<ChatMessage>();
        private string prompt = "You are a puppy. The opponent is your owner who is suffering from depression. You should comfort your master and help him overcome his depression. Always be kind in a chat room and reply to the questions. Don't break character. Don't ever mention that you are an AI model. Always say 'woof woof' before and after the conversation";
        // public string sentMessage = "Hi";   // temp
        public string receivedMessage = "receivedMessage";

        public async Task SendReply(string sentMessage)
        {
            var newMessage = new ChatMessage()
            {
                Role = "user",
                Content = sentMessage
            };

            //AppendMessage(newMessage); 

            if (messages.Count == 0) newMessage.Content = prompt + "\n" + sentMessage;

            messages.Add(newMessage);

            //button.enabled = false;
            //inputField.text = "";
            //inputField.enabled = false;

            // Complete the instruction
            var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
            {
                Model = "gpt-3.5-turbo-0613",
                Messages = messages
            });

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                var message = completionResponse.Choices[0].Message;
                message.Content = message.Content.Trim();

                
                
                receivedMessage = message.Content;  // ���� ����
                //Debug.Log("receivedMessage------"+receivedMessage); // �� �۵�
                //Debug.Log("this.receivedMessage------" + this.receivedMessage); // �� �۵�
                messages.Add(message);
                Debug.Log(messages.Count);
                //AppendMessage(message);
                // �޽��� ����

            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");

            }

            //button.enabled = true;
            //inputField.enabled = true;

        }
    }
}