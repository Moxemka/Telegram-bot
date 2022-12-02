using System;
using System.Text.RegularExpressions;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Wolfram.Alpha;
using Wolfram.Alpha.Models;

namespace Proga
{
    class Program
    {
        public static bool end = true;

        static ITelegramBotClient botClient;
        /// <summary>
        /// Сам Бот
        /// </summary>

        [STAThread]
        static void Main()
        {
            botClient = new TelegramBotClient("916927551:AAHOW9Zu02b9SIX3nRCLWgGqR-ANf0y8tAM");

            var me = botClient.GetUpdatesAsync();
            Console.WriteLine(
              $"Bot Initialised"
            );
            while (true)
            {
                try
                {
                    botClient.OnMessage += Bot_OnMessage;
                    botClient.StartReceiving();
                    Thread.Sleep(int.MaxValue);
                }
                catch 
                {
                    Console.WriteLine("for idea deadlock exeption");
                }
            }
        }

        /// <summary>
        /// Реакция на входящие
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {

            switch (e.Message.Text)
            {
                case "/help":
                    Console.WriteLine($"Какойто Юзверь попросил помощи.");

                    await botClient.SendTextMessageAsync(
                      chatId: e.Message.Chat,
                      text: "Список правил работы с ботом:\n 1)Не спамить \n 2)Чтобы работать боту нужно время от 20 до 60 с."
                    );
                    break;
                case "/start":
                    await botClient.SendTextMessageAsync(
                      chatId: e.Message.Chat,
                      text: "Крутой, написал старт\n"
                    );
                    break;
                case "/dickpick":
                    Console.WriteLine("ДИКПИКЕР!!!!.");
                    #region РЖАКА
                    Random r = new Random();
                    int a = r.Next(1, 3);
                    if (a == 1)
                    {
                        await botClient.SendPhotoAsync(
                                          chatId: e.Message.Chat,
                                          photo: "https://sun9-14.userapi.com/c853528/v853528429/1a39bf/alBosKYlFoU.jpg"
                                        );
                    }
                    else
                    if (a == 2)
                    {
                        await botClient.SendPhotoAsync(
                                          chatId: e.Message.Chat,
                                          photo: "https://sun9-40.userapi.com/c858528/v858528829/ae126/UetDMRngmSw.jpg"
                                        );
                    }
                    else
                        if (a == 3)
                    {
                        await botClient.SendPhotoAsync(
                                          chatId: e.Message.Chat,
                                          photo: "https://sun9-40.userapi.com/c858528/v858528829/ae126/UetDMRngmSw.jpg"
                                        );
                    }
                    #endregion
                    break;
            }
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Текст Юзверя {e.Message.Text}.");
                try
                {
                    WolframAlphaService service = new WolframAlphaService("LVX4W5-R2WGGY9JU5");
                    WolframAlphaRequest request = new WolframAlphaRequest(e.Message.Text);
                    WolframAlphaResult result = await service.Compute(request);
                    Regex regex = new Regex(@"[/]");

                    foreach (var pod in result.QueryResult.Pods)
                    { 
                        
                        if (pod.SubPods != null)
                        {

                            if (pod.Title == "Result")
                            {
                                Console.WriteLine(pod.Title);
                                foreach (var subpod in pod.SubPods)
                                {
                                    Console.WriteLine("    " + subpod.Plaintext);
                                    await botClient.SendTextMessageAsync(
                                      chatId: e.Message.Chat,
                                      text: "Ответ :\n" + subpod.Plaintext
                                    );
                                }
                            }
                            if (((pod.Title == "Solutions") || (pod.Title == "Solution")) && (end))
                            {
                                string output = String.Empty;

                                Console.WriteLine(pod.Title);
                                Console.WriteLine("input");
                                foreach (var subpod in pod.SubPods)
                                {
                                    Console.WriteLine("    " + subpod.Plaintext);
                                    output += subpod.Plaintext + ";\n";

                                }
                                await botClient.SendTextMessageAsync(
                                      chatId: e.Message.Chat,
                                      text: "Ответ :\n" + output
                                    );
                            }
                            if (pod.Title == "Input interpretation")
                            {
                                Console.WriteLine(pod.Title);
                                foreach (var subpod in pod.SubPods)
                                {
                                    Console.WriteLine("    " + subpod.Plaintext);
                                    await botClient.SendTextMessageAsync(
                                      chatId: e.Message.Chat,
                                      text: "Ответ :\n" + subpod.Plaintext
                                    );

                                }
                            }
                            if (pod.Title == "Derivatve" || pod.Title == "Real root")
                            {
                                Console.WriteLine(pod.Title);
                                foreach (var subpod in pod.SubPods)
                                {
                                    Console.WriteLine("    " + subpod.Plaintext);
                                    await botClient.SendTextMessageAsync(
                                      chatId: e.Message.Chat,
                                      text: "Ответ :\n" + subpod.Plaintext
                                    );

                                }
                            }
                            if (pod.Title == "Integer solution")
                            {
                                Console.WriteLine(pod.Title);
                                foreach (var subpod in pod.SubPods)
                                {
                                    Console.WriteLine("    " + subpod.Plaintext);
                                    await botClient.SendTextMessageAsync(
                                      chatId: e.Message.Chat,
                                      text: "Ответ :\n" + subpod.Plaintext
                                    );

                                }
                            }
                            if (pod.Title == "Real solutions")
                            {
                                Console.WriteLine(pod.Title);
                                foreach (var subpod in pod.SubPods)
                                {
                                    Console.WriteLine("    " + subpod.Plaintext);
                                    await botClient.SendTextMessageAsync(
                                      chatId: e.Message.Chat,
                                      text: "Ответ :\n" + subpod.Plaintext
                                    );

                                }
                            }


                           
                            if (pod.Title == "Complex solutions")
                            {
                                Console.WriteLine(pod.Title);
                                foreach (var subpod in pod.SubPods)
                                {
                                    Console.WriteLine("    " + subpod.Plaintext);
                                    await botClient.SendTextMessageAsync(
                                      chatId: e.Message.Chat,
                                      text: "Ответ :\n" + subpod.Plaintext
                                    );

                                }
                            }

                            if (pod.Title == "Exact result")
                            {
                                Console.WriteLine(pod.Title);
                                foreach (var subpod in pod.SubPods)
                                {
                                    Console.WriteLine("    " + subpod.Plaintext);
                                    await botClient.SendTextMessageAsync(
                                      chatId: e.Message.Chat,
                                      text: "Ответ :\n" + subpod.Plaintext
                                    );

                                }
                            }
                        }
                    }
                   
                    end = true;
                    Console.WriteLine("_________________________________________________________________________");
                    
                }
                catch
                {
                    await botClient.SendTextMessageAsync(
                                      chatId: e.Message.Chat,
                                      text: "Проверьте, правильно ли был сделан ввод строки"
                                    );
                    
                }


                

            }
        }









    }




}