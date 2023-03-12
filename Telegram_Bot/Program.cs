using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_Bot
{
    class Program
    {
        private static string token { get; set; } = "5942927062:AAGVXoKnYy44DNsUSjz_W5bWlxY_qK-bz9w";
        private static TelegramBotClient client;

        static void Main(string[] args) 
        {

            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();          
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом: {msg.Text}");
                switch (msg.Text)
                {

                    case "Стикер":
                        await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://stickerswiki.ams3.cdn.digitaloceanspaces.com/MotivationToaster/170586.160.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;
                    case "Картинка":
                        await client.SendPhotoAsync(
                            chatId: msg.Chat.Id,
                            photo: "https://klike.net/uploads/posts/2020-03/1585471522_2.jpg",
                            replyMarkup: GetButtons());
                        break;

                   

                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Выберите команду: ", replyMarkup: GetButtons());
                        break;
                }
            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Стикер"}, new KeyboardButton { Text = "Картинка"} },
                    

                }
            };
        }
    }
}