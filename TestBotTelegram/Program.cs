using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TestBotTelegram
{
    class Program
    {
      private static readonly  TelegramBotClient botClient = new TelegramBotClient("");

        static void Main(string[] args)
        {
            botClient.OnMessage += BotClient_OnMessage;
            botClient.OnMessageEdited += BotClient_OnMessage;


            botClient.StartReceiving();
            Console.ReadLine();
            botClient.StopReceiving();

        }

        //private static void BotClient_OnMessageEdited(object sender, Telegram.Bot.Args.MessageEventArgs e)
        //{
        //    if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
        //    {
        //        if(e.Message.Text == "/How are you?")
        //        {
        //            botClient.SendTextMessageAsync(e.Message.Chat.Id,"I am Fine :)");
        //        }
        //    }
        //}

        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            using (var contex = new TestDbContext())
            {

                if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                {
                    Console.WriteLine(e.Message.Text);
                    if (contex.products.Any(x => x.ProductName == e.Message.Text))
                    {
                        var price = contex.products.First(p => p.ProductName.Equals(e.Message.Text));

                        botClient.SendTextMessageAsync(e.Message.Chat.Id, price.Price + " Azn");
                    }
                    else if(contex.products.Any(x=> x.ProductName != e.Message.Text))
                    {
                        var product = contex.products.Where(x => x.ProductName.StartsWith(e.Message.Text));
                        foreach (var item in product)
                        {
                            botClient.SendTextMessageAsync(e.Message.Chat.Id, item.ProductName + "--" + item.Price + " AZN");
                        }
                    }
                    else
                        botClient.SendTextMessageAsync(e.Message.Chat.Id,"Coming soon :)))) ");

                }
            }
        }
    }
}
