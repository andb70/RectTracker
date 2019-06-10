using System;
using System.Collections.Generic;
using System.Timers;

namespace RectTracker
{
    class Program
    {
        // this will be accessed from within NewQR
        // which is the AI job callback
        static Perimeter perimeter;

        static void Main(string[] args)
        {
            // load the map of the place from a json file
            perimeter = Geometry.LoadPerimeter("pathToPerimeter.json");

            // simulatyion pourpose:
            // simulate the event release by the AI software
            Timer CameraEvent = new Timer
            {
                Interval = 1000,
                Enabled= true
            };
            CameraEvent.Elapsed += CameraEvent_Elapsed;
            CameraEvent.Start();


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static void NewQR(QRinfo info)
        {
            // new AI job completed, we have a info object and we wanto to identify the zone
            // where we found the QR
            Zone z = Geometry.RectToZone(info.Rect, perimeter.Zones);
            // add the zone Id to the QRinfo object
            info.ZoneId = z.Id;

            // pay attention to zonee which are not step-able
            Console.WriteLine($"\ncarrello con Id = {info.QRId} rilevato nella zona '{z.Name}' - id = {z.Id}");
            if (z.Name == "e")
            {
                Console.WriteLine($"   la zona non è calpestabile");
            }

            Console.WriteLine($"     {info.Rect.Top},{info.Rect.Left}       Top, Left      {z.Rect.Top},{z.Rect.Left}");
            Console.WriteLine($"     {info.Rect.Top + info.Rect.Height},{info.Rect.Left + info.Rect.Width}     Bottom, Right    {z.Rect.Top + z.Rect.Height},{z.Rect.Left + z.Rect.Width}");

            // send the object to the consumer
        }

        private static void CameraEvent_Elapsed(object sender, ElapsedEventArgs e)
        {
            // simulate the AI job, which calls NewQR and pass a info object
            Random r = new Random();
            QRinfo info = new QRinfo
            {
                QRId = r.Next(1, 5), // un carrello a caso di 5
                Rect = new Rect()
                {
                    Left = r.Next(0, 1280 - 20),
                    Top = r.Next(0, 720 - 20),
                    Width = 20,
                    Height = 20
                },
                TimeStamp = DateTime.Now
            };
            NewQR(info);
        }
    }
}
