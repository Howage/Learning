using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Chapter1
{
    public static class Program
    {

        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });

        //public static void ThreadMethod(object o)
        //{
        //    for (int i = 0; i < (int)o; i++)
        //    {
        //        Console.WriteLine("Threadproc: {0}" , i);
        //        Thread.Sleep(1000);
        //    }
        //}
        //public static void Main()
        //{
        //    new Thread(() =>
        //    {
        //        for (int x = 0; x <_field.Value; x++)

        //        {

        //            Console.WriteLine("Thread A : {0}", x);
        //        }
        //    }).Start();
        //    {
        //        new Thread(() =>
        //        {
        //            for (int x = 0; x < _field.Value; x++)

        //            {
        //                Console.WriteLine("Thread B : {0}", x);
        //            }
        //        }).Start();
        //        Console.ReadKey();


        //        //for (int i = 0; i<4; i++)
        //{
        //    Console.WriteLine( "Main thread: Do Some work.");
        //    Thread.Sleep(0);
        //}

        //t.Join();

        //public static void Main()
        //{
        //    ThreadPool.QueueUserWorkItem((s) =>
        //    {
        //        Console.WriteLine("Working on a thread from the Threadpool");
        //    });
        //    Console.ReadLine();
        //}
        //public static void Main()
        //{
        //    Task<int> t = Task.Run(() =>
        //    {
        //        return 42;
        //    });
        //    t.ContinueWith((i) =>

        //   {
        //       Console.WriteLine("Cancelled");

        //   }, TaskContinuationOptions.OnlyOnCanceled);
        //    t.ContinueWith((i) =>

        //    {
        //        Console.WriteLine("Faulted");

        //    }, TaskContinuationOptions.OnlyOnFaulted);

        //   var completedTask  = t.ContinueWith((i) =>

        //    {
        //        Console.WriteLine("Compelted");

        //    }, TaskContinuationOptions.OnlyOnRanToCompletion);

        //    completedTask.Wait();
        //    Console.WriteLine(t.Result);
        //}

        public static void Main()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];

                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);

                return results;

            });

            var finalTask = parent.ContinueWith(
                parentTask =>
                {
                    foreach (int i in parentTask.Result)
                        Console.WriteLine(i);
                });
            finalTask.Wait();
        }
    }
}
    



