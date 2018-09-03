using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice2.algorithm
{
    public class ThreadAlgorithm
    {
        private static int _counter = 0;
        private static Mutex _counterMutex;
        private static Mutex _stateMutex;
        private const int TIME = 1000;
        private const int LIMIT = 50;
        private static bool _run;

        public static void HandleFizzBuzz()
        {
            _counterMutex = new Mutex();
            _stateMutex = new Mutex();

            var counterThread = new Thread(Counter);
            var fizzThread = new Thread(Fizz);
            var buzzThread = new Thread(Buzz);
            var fizzBuzzThread = new Thread(FizzBuzz);

            _run = true;

            counterThread.Start();
            fizzThread.Start();
            buzzThread.Start();
            fizzBuzzThread.Start();

            counterThread.Join();
            fizzThread.Join();
            buzzThread.Join();
            fizzBuzzThread.Join();

            Console.WriteLine("Finish!");

            var _ = Console.ReadLine();
        }

        private static void Counter()
        {
            while (_counter < LIMIT)
            {
                _counterMutex.WaitOne();
                _counter++;
                Thread.Sleep(TIME / 10);
                _counterMutex.ReleaseMutex();
            }
            _stateMutex.WaitOne();
            _run = false;
            _stateMutex.ReleaseMutex();
        }

        private static void Fizz()
        {
            var value = -1;
            _stateMutex.WaitOne();
            while (_run)
            {
                _stateMutex.ReleaseMutex();
                _counterMutex.WaitOne();
                if (_counter % 3 == 0 && value != _counter)
                {
                    Console.WriteLine($"Fizz {_counter}");
                    Thread.Sleep(TIME);
                    value = _counter;
                }
                _counterMutex.ReleaseMutex();
                _stateMutex.WaitOne();
            }
            _stateMutex.ReleaseMutex();
        }

        private static void Buzz()
        {
            var value = -1;
            _stateMutex.WaitOne();
            while (_run)
            {
                _stateMutex.ReleaseMutex();
                _counterMutex.WaitOne();
                if (_counter % 5 == 0 && value != _counter)
                {
                    Console.WriteLine($"Buzz {_counter}");
                    Thread.Sleep(TIME);
                    value = _counter;
                }
                _counterMutex.ReleaseMutex();
                _stateMutex.WaitOne();
            }
            _stateMutex.ReleaseMutex();
        }

        private static void FizzBuzz()
        {
            var value = -1;
            _stateMutex.WaitOne();
            while (_run)
            {
                _stateMutex.ReleaseMutex();
                _counterMutex.WaitOne();
                if (_counter % 3 == 0 && _counter % 5 == 0 && value != _counter)
                {
                    Console.WriteLine($"FizzBuzz {_counter}");
                    Thread.Sleep(TIME);
                    value = _counter;
                }
                _counterMutex.ReleaseMutex();
                _stateMutex.WaitOne();
            }
            _stateMutex.ReleaseMutex();
        }
    }
}
