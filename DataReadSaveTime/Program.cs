using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataReadSaveTime.Models;
using System.Diagnostics;
using System.IO;

namespace DataReadSaveTime
{
    public class Program
    {

        public static void Main(string[] args)
        {
            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");
            LoggerClass.NLogInfo("処理開始");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int n = 0; n < 30; n++)
            {
                List<Task> task = new List<Task>();
                task.Add(FileTest.FileSave());
                Task.WaitAll(task.ToArray());
                LoggerClass.NLogInfo("保存：時間経過: " + stopwatch.ElapsedMilliseconds + "ms");
                List<Task> task2 = new List<Task>();
                task2.Add(FileTest.FileRead());
                Task.WaitAll(task2.ToArray());
                LoggerClass.NLogInfo("読込：時間経過: " + stopwatch.ElapsedMilliseconds + "ms");
            }
        }
    }
}
