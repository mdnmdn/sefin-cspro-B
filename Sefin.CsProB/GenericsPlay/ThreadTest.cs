using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericsPlay
{
    [Category("test")]
    public class ThreadTest
    {
        public void Thread1()
        {
            //var thread = new Thread(ThreadStart ...)

            var threadId = Thread.CurrentThread.ManagedThreadId;

            Trace.WriteLine($"--- start {threadId} ----");

            ThreadPool.QueueUserWorkItem(_ => {
                var threadId2 = Thread.CurrentThread.ManagedThreadId;
                Trace.WriteLine($" > faccio cose {threadId}");

                Trace.WriteLine($" > finito");

            });

            Thread.Sleep(500);

            Trace.WriteLine($"--- end {threadId} ----");
        }

        public void ThreadMulipli()
        {
            //var thread = new Thread(ThreadStart ...)

            var threadId = Thread.CurrentThread.ManagedThreadId;

            Trace.WriteLine($"--- start {threadId} ----");


            for (int i = 1; i < 40; i++)
            {
                var num = i;
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    var threadId2 = Thread.CurrentThread.ManagedThreadId;
                    Trace.WriteLine($" {num}> faccio cose {threadId2}");
                    Thread.Sleep(500);
                    Trace.WriteLine($" {num}> finito");

                });
            }

            Thread.Sleep(500);

            Trace.WriteLine($"--- end {threadId} ----");
        }

        public void ThreadSync1()
        {
            //var thread = new Thread(ThreadStart ...)

            var threadId = Thread.CurrentThread.ManagedThreadId;

            Trace.WriteLine($"--- start {threadId} ----");

            object lockObject = new Object();

            ThreadPool.QueueUserWorkItem(_ => {
                var threadId2 = Thread.CurrentThread.ManagedThreadId;

                lock (lockObject)
                {
                    Trace.WriteLine($" > faccio cose su db {threadId2}");
                    Thread.Sleep(new Random().Next(2000) + 400);
                    Trace.WriteLine($" > finito");
                }
            });

            ThreadPool.QueueUserWorkItem(_ => {
                var threadId2 = Thread.CurrentThread.ManagedThreadId;

                lock (lockObject)
                {
                    Trace.WriteLine($" > faccio cose su WS{threadId2}");
                    Thread.Sleep(new Random().Next(2000) + 400);
                    Trace.WriteLine($" > finito");
                }
            });

            Thread.Sleep(500);

            Trace.WriteLine($"--- end {threadId} ----");
        }

        public void Task1() {

            var threadId = Thread.CurrentThread.ManagedThreadId;

            Trace.WriteLine($"--- start {threadId} ----");

            var task = new Task(() =>
            {
                var threadId2 = Thread.CurrentThread.ManagedThreadId;
                Trace.WriteLine($" > faccio cose su WS{threadId2}");
                Thread.Sleep(new Random().Next(2000) + 400);
                Trace.WriteLine($" > finito WS");
            });

            task.Start();

            var task2 = new Task(() =>
            {
                var threadId2 = Thread.CurrentThread.ManagedThreadId;
                Trace.WriteLine($" > faccio cose su DB {threadId2}");
                Thread.Sleep(new Random().Next(2000) + 400);
                Trace.WriteLine($" > finito DB");
            });

            task2.Start();


            var taskNum = new Task<int>(() =>
            {
                var threadId2 = Thread.CurrentThread.ManagedThreadId;
                Trace.WriteLine($" > Cal {threadId2}");
                var wait = new Random().Next(2000) + 400;
                Thread.Sleep(wait);
                Trace.WriteLine($" > finito DB");
                return wait;
            });

            //taskNum.Start();

            //Task.WaitAll(task, task2,taskNum);

            Trace.WriteLine($" taskNum: {taskNum.Result}");
            

            Trace.WriteLine($"--- end {threadId} ----");



            //var val = new Task<int>(() =>
            //{
            //    var threadId2 = Thread.CurrentThread.ManagedThreadId;
            //    Trace.WriteLine($" > Cal {threadId2}");
            //    var wait = new Random().Next(2000) + 400;
            //    Thread.Sleep(wait);
            //    Trace.WriteLine($" > finito DB");
            //    return wait;
            //}).Result;

        }


        public void Parallels() {
            var threadId = Thread.CurrentThread.ManagedThreadId;

            Trace.WriteLine($"--- start {threadId} ----");


            var nums = Enumerable.Range(1, 40);

            Parallel.ForEach(nums, num =>
            {
                var threadId2 = Thread.CurrentThread.ManagedThreadId;
                Trace.WriteLine($" {num}.> faccio cose su num {num} {threadId2}");
                Thread.Sleep(10);
                Trace.WriteLine($" {num}.> finito");
            });

            Trace.WriteLine($"--- end {threadId} ----");
        }

        public async void AsyncPlay() {
            try
            {
                var doc = await LoadDocument();
            }
            catch (Exception ex) {

            }


            var ids = await ReadCompanies();

            List<Task> tasks = new List<Task>();

            //TaskScheduler.Current.

            foreach (var id in ids) {
                tasks.Add(ProcessCompanyData(id));
            }

            Task.WaitAll(tasks.ToArray());

            // ....
        }

        public async Task<Document> LoadDocument() {
            
            // corretto
            var task = await Task.Run(() =>
            {
                var threadId2 = Thread.CurrentThread.ManagedThreadId;
                Trace.WriteLine($" > carico doc {threadId2}");
                Thread.Sleep(300);
                Trace.WriteLine($" > finito");
                return new Document {
                    Id = 23,
                    Name = "sddddd"
                };
            });

            return task;
        }

        public async Task<List<string>> ReadCompanies() {
            return null;
        }

        public async Task<DataTable> ProcessCompanyData(string id)
        {
            return null;
        }
    }
}
