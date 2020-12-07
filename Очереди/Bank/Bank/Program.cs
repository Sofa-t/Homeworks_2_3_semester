using System;
using System.Collections.Generic;


namespace Bank
{
    class Program
    {

        static void Main()
        {
            double lambda = 15; //интенсивность потока - среднее количество клиентов в час
            int timeIntervalInSeconds = 5; //промежуток, в течение которого проверяется, пришел ли новый клиент     

            //приход в банк клиентов моделируется на основе простейшего потока случайных событий
            double p = Math.Pow(Math.E, -lambda * timeIntervalInSeconds / (60*60)); //вероятность того, что в заданный временной интервал клиент не придет

            for (DateTime timer = Bank.DayStart; timer < Bank.DayEnd; timer = timer.AddSeconds(timeIntervalInSeconds))
            {
                //Увеличиваем время на timeIntervalInSeconds
                Bank.CurrentTime = Bank.CurrentTime.AddSeconds(timeIntervalInSeconds);
                                
                //Пришел ли новый клиент в интервал timeIntervslInSeconds
                if (Client.Rnd.NextDouble() > p) //клиент пришел
                {
                    ... //ставим нового клиента в очередь на обслуживание
                }

                ServeClient();
            }

            while (Bank.BankQueue.Count > 0)
            {
                ... // продолжаем обслуживать клиентов, которые встали в очередь до закрытия банка
            }

            Console.ReadKey();
        }

        static void ServeClient()
        {
            var freeWindow = Bank.GetEmptyWindow(); 

            if (freeWindow != null && Bank.BankQueue.Count > 0) 
            {
                ... // если  есть свободное окно и есть клиенты в очереди, это окно берет очередного клиента на обслуживание и объявляет об этом
            }
        }

    }
}
