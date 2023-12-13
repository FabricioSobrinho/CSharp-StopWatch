using System;

namespace StopWatch
{
    class Program
    {
        public static void Main(string[] args)
        {
            ClockMenu();
        }

        static void StartCount(int time, char type)
        {
            int currentTime = 0;
            int seconds = 0;
            int minutes = 0;

            while (currentTime != time)
            {
                Console.Clear();

                currentTime++;

                Console.WriteLine($"""
                |--=--|
                |{ToFixValue(minutes)}:{ToFixValue(seconds)}|
                |--=--|
                """);

                seconds++;

                if (seconds == 60)
                {
                    seconds = 0;
                    minutes++;
                }

                Thread.Sleep(1000);
            }
            Console.Clear();
            Console.WriteLine("Stop Clock.");
            Thread.Sleep(500);
        }
        static void PreStart(int time, char type)
        {
            Console.Clear();

            Console.WriteLine("Ready?");
            Thread.Sleep(1000);

            Console.WriteLine("set?");
            Thread.Sleep(1000);

            Console.WriteLine("Go!");
            Thread.Sleep(1000);

            StartCount(time, type);
        }

        static void ClockMenu()
        {
            Console.Clear();
            try
            {
                Console.WriteLine(
                    """
                    |----------------------------|
                    |How much time do you need?" |
                    |============================|
                    |S - seconds, example => 10s |
                    |M - Minutes, example => 5m  |
                    |0 - exit                    |
                    |----------------------------|
                    """
                );

                string data = Console.ReadLine()!.ToLower();

                char type = char.Parse(data.Substring(data.Length - 1, 1));

                int time = Convert.ToInt32(data.Substring(0, data.Length - 1));

                int multiplier = type == 's' ? 1 : 60;

                if (time == 0) System.Environment.Exit(0);

                PreStart(time * multiplier, type);
            }
            catch
            {
                Console.WriteLine("An unexpected error happens.");
            }
        }

        private static bool IsNotNull(string data)
        {
            throw new NotImplementedException();
        }

        static string ToFixValue(int number)
        {
            if (number < 10)
            {
                return "0" + number;
            }

            return number.ToString();
        }
    }
}