using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Pinger
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ipinfo;
                string iprepeat;
                Console.Write("Enter Domain or IP:  (DONT USE ILLEGALLY NOT OUR ISSUE RETARDS)");
                ipinfo = Console.ReadLine();
                Console.Write("Would you like repeating ping checks: ");
                iprepeat = Console.ReadLine();
                if (iprepeat == "yes")
                {
                    Console.WriteLine("Repeated IP Check set to true");
                    Ping P1 = new Ping();
                    PingReply PR = P1.Send(ipinfo);
                    PingReply sender = P1.Send(ipinfo);
                    if (sender != null)
                    {
                        Console.WriteLine("───────────────────────────────────");
                        Console.WriteLine("Pinged server request [" + sender.RoundtripTime.ToString() + "ms]");
                        Console.WriteLine("Status: " + sender.Status);
                        Console.WriteLine("Requested IP: " + sender.Address);
                        Console.WriteLine("───────────────────────────────────");

                        while (!PR.Status.ToString().Equals("Success"))
                        {
                            Console.WriteLine(PR.Status.ToString());
                            PR = P1.Send(ipinfo);
                        }
                        while (PR.Status.ToString().Equals("Success"))
                        {
                            Console.WriteLine(PR.Status.ToString() + " in [" + sender.RoundtripTime.ToString() + "ms] | " + DateTime.Now.ToString());
                            PR = P1.Send(ipinfo);
                        }
                    }
                } else if (iprepeat == "no")
                {
                    Console.WriteLine("Repeated IP Check set to false");

                    Ping P1 = new Ping();
                    PingReply sender = P1.Send(ipinfo, 1000);
                    if (sender != null)
                    {
                        Console.WriteLine("───────────────────────────────────");
                        Console.WriteLine("Pinged server request [" + sender.RoundtripTime.ToString() + "ms]");
                        Console.WriteLine("Status: " + sender.Status);
                        Console.WriteLine("Requested IP: " + sender.Address);
                        Console.WriteLine("───────────────────────────────────");

                    }
                }
                else
                {
                    Console.WriteLine("Please input yes/no");
                }


            }
            catch
            {
                Console.WriteLine("ERROR: Could not connect to requested IP");
            }
            Console.ReadKey();
        }
    }
}
