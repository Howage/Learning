using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1_Threading
{
    public static class Program
    {

        public static ThreadLocal<int> Field =
            new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

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

        //public static void Main()
        //{
        //    Task<Int32[]> parent = Task.Run(() =>
        //    {
        //        var results = new Int32[3];

        //        TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
        //            TaskContinuationOptions.ExecuteSynchronously);

        //        tf.StartNew(() => results[0] = 0);
        //        tf.StartNew(() => results[1] = 1);
        //        tf.StartNew(() => results[2] = 2);

        //        return results;

        //    });

        //    var finalTask = parent.ContinueWith(
        //        parentTask =>
        //        {
        //            foreach (int i in parentTask.Result)
        //                Console.WriteLine(i);
        //        });
        //    finalTask.Wait();
        //}

        //Can use wait any and Wait all as well - Waitall will wait for all tasks to complete. WaitAny for a the first to finish. 

        // parallel Classes
        // Used for parallell processing 

        //Static Methods : For, ForEach, and Invoke
        // parallelism involves taking a certain task and splitting in into a set of related tasks that can be executed concurrently.
        // should only be used when your code doesnt have to be executed sequentially.

        public static void Main()
        {
            ParallelLoopResult result = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                if (i != 500) return;
                Console.WriteLine("Breaking Loop");
                loopState.Break();
         
            });
        }
    }
}
    



