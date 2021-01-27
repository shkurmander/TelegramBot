using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace TestBot
{
    public class Conversation
    {
        private Chat telegramChat;

        private List<Message> telegramMessages;

        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();

        }
    }
}
