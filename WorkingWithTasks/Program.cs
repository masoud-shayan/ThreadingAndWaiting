using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WorkingWithTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var timer = Stopwatch.StartNew();
            
            
            // Console.WriteLine("Running methods synchronously on one thread.");
            // MethodA();
            // MethodB();
            // MethodC();
            // Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
            
            
            Console.WriteLine("Running methods asynchronously on multiple Threads");

            //1
            Task taskA = new Task(MethodA);
            taskA.Start();

            //2
            var taskB = Task.Factory.StartNew(MethodB);

            //3
            var taskC = Task.Run(new Action(MethodC));


            // add this part of code to console task (main task) wait for all other tasks to finish and then continue, otherwise it disregards other tasks and go to finish the running immediately 

            Task[] tasks =new [] {taskA, taskB, taskC};

            Task.WaitAll(tasks);
            
            

            Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");


        }
        
        
        
        static void MethodA()
        {
            Console.WriteLine("Starting Method A...");
            Thread.Sleep(3000); // simulate three seconds of work
            Console.WriteLine("Finished Method A.");
        }
        static void MethodB()
        {
            Console.WriteLine("Starting Method B...");
            Thread.Sleep(2000); // simulate two seconds of work
            Console.WriteLine("Finished Method B.");
        }
        static void MethodC()
        {
            Console.WriteLine("Starting Method C...");
            Thread.Sleep(1000); // simulate one second of work
            Console.WriteLine("Finished Method C.");
        }
    }
}