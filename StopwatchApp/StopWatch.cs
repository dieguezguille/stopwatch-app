using System;
using System.Net.Mime;
using System.Runtime.InteropServices.ComTypes;

namespace StopwatchApp
{
    public class StopWatch
    {
        //Fields
        private DateTime _startTime;
        private DateTime _stopTime;
        private bool _isRunning = false;
        
        //Properties

        //Methods
        public void Start()
        {
            if (_isRunning)
            {
                throw new InvalidOperationException("StopWatch is already running!");
            }
            else
            {
                //Inicia el cronómetro
                _startTime = DateTime.Now;
                _isRunning = true;

                Console.WriteLine("StopWatch Running... Press 'S' to Stop.");

                var tecla = Console.ReadKey(intercept: true);

                while (tecla.Key != ConsoleKey.S)
                {
                    tecla = Console.ReadKey(intercept: true);
                }

                Stop();
            }

        }

        public void Stop()
        {
            //Detiene el cronómetro
            _stopTime = DateTime.Now;
            _isRunning = false;

            //Calcula duración
            TimeSpan durationTime = _stopTime - _startTime;

            //Muestra en la consola la duracion
            Console.WriteLine($"StopWatch elapsed time is: {durationTime.Hours} hours, {durationTime.Minutes} minutes, {durationTime.Seconds} seconds");
            Console.WriteLine("Press 'S' to Start again or 'E' to exit.");

            
            bool flag = true;
            while (flag)
            {
                //Almacena la tecla del ususario
                var tecla = Console.ReadKey(intercept: true);

                //Chequea la tecla del usuario
                switch (tecla.Key)
                {
                    case ConsoleKey.S:
                        flag = false;
                        Start();
                        break;
                    case ConsoleKey.E:
                        System.Environment.Exit(0);
                        break;
                    default:
                        flag = true;
                        Console.WriteLine("Please enter a valid key.");
                        break;
                }
            }


        }
    }
}