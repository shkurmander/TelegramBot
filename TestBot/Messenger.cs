using System;

namespace TestBot
{
    internal class Messenger
    {
        internal string CreateTextMessage(Conversation chat)
        {
            string delimiter = ", ";
            string text = "Your history: ";

            text += string.Join(delimiter, chat.GetTextMessages().ToArray());
            chat.GetTextMessages();
            return text;
        }
    }
}