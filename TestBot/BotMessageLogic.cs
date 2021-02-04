using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TestBot
{
    public class BotMessageLogic
    {
        private Messenger messenger;

        private Dictionary<long, Conversation> chatList;

        private ITelegramBotClient botClient;

        public BotMessageLogic(ITelegramBotClient botClient)
        {
            messenger = new Messenger();
            chatList = new Dictionary<long, Conversation>();
            this.botClient = botClient;
        }
        public async  Task Response(MessageEventArgs e)
        {
            var id = e.Message.Chat.Id;
            if (!chatList.ContainsKey(id))
            {
                var newchat = new Conversation(e.Message.Chat);
                chatList.Add(id, newchat);
            }

            var chat = chatList[id];
            chat.AddMessage(e.Message);

            await SendTextMessage(chat);
        }

        private async Task SendTextMessage(Conversation chat)
        {
            var text = messenger.CreateTextMessage(chat);

            await botClient.SendTextMessageAsync(chatId:chat.GetId(), text: text);
        }
    }
}
