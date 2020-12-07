using System;
using System.Collections.Generic;


namespace Bank
{
    class Client
    {
        public static Random Rnd = new Random();

        public int TicketNumber { get; set; } //номер полученного талона электронной очереди
        public int TimeToServeInMinutes { get; set; } //время, требуемое для обслуживания клиента        

        public Client()
        {
            TicketNumber = Bank.LastTicketNumber++;
            TimeToServeInMinutes = Rnd.Next(2, 6) * 5; // равновозможное время, необходимое для работы с клиентом - 10, 15, 20 или 25 минут
        }
    }

    static class Bank
    {
        public class Window
        {

            public int WindowNumber; // номер окна
            public Client CurrentClient { get; set; } //обслуживаемый в настоящий момент клиент
            public DateTime NextClientTime; //время начала обслуживания следующего клиента

            public void ChangeClient(Client newClient)
            {
                CurrentClient = newClient;
                NextClientTime = Bank.CurrentTime.AddMinutes(newClient.TimeToServeInMinutes);
            }

            public void Anounce()
            {
                Console.WriteLine("{0,8:T} №{1,3} Окно {2}.", CurrentTime, CurrentClient.TicketNumber, WindowNumber+1);
            }
        }

        

        const int NumberOfWindows = 4; //количество окон для работы с клиентами в операционном зале банка 

        public static Queue<Client> BankQueue { get; set; } //очередь клиентов, ожидающих обслуживания
        public static Window[] Windows { get; set; } //массив окон для работы с клиентами
        public static int LastTicketNumber { get; set; } //номер последнего выданного талона электронной очереди
        public static DateTime CurrentTime; //текущее время
        public static DateTime DayStart = new DateTime().AddHours(9); //банк начинает принимать новых клиентов в 9.00
        public static DateTime DayEnd = new DateTime().AddHours(19); //банк заканчивает принимать новых клиентов в 19.00

        /// <summary>
        /// Метод находит первое свободное окно в операционном зале,
        /// </summary>
        /// <returns>
        /// Возвращает окно, освободившееся раньше других, если таковое имеется.
        /// Если нет - возвращает null
        /// </returns>
        public static Window GetEmptyWindow()
        {
            Window result = null;
            foreach (var window in Windows)
                if (window.NextClientTime <= CurrentTime &&
                        (result == null || window.NextClientTime < result.NextClientTime))
                    result = window;
            return result;
        }

        static Bank()
        {
            BankQueue = new Queue<Client>();
            CurrentTime = DayStart;
            LastTicketNumber = 0;
            Windows = new Window[NumberOfWindows];
            for (var i = 0; i < NumberOfWindows; i++)
                Windows[i] = new Window() { WindowNumber = i, NextClientTime = CurrentTime };
        }

    }
}
