﻿using System;
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

        internal void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }

        internal long  GetId()
        {
            return telegramChat.Id;
        }

        public List<string> GetTextMessages()
        {
            var textMessages = new List<string>();

            foreach (var message in telegramMessages)
            {
                if (message.Text != null)
                {
                    textMessages.Add(message.Text);
                }
            }

            return textMessages;
        }
    }
}
