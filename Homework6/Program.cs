using Homework6;
using System.Diagnostics;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task)."); 
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var res1 = Task1(@"D:\Test\File1.txt", @"D:\Test\File2.txt", @"D:\Test\File3.txt");
        stopWatch.Stop();
        foreach (var task in res1)
        {
            Console.WriteLine(task);
        }
        Console.WriteLine($"Время: {stopWatch.ElapsedTicks}");


        Console.WriteLine("Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них");
        stopWatch.Reset();
        stopWatch.Start();
        var res2 = Task2();
        stopWatch.Stop();
        foreach (var task in res2)
        {
            Console.WriteLine(task);
        }
        Console.WriteLine($"Время: {stopWatch.ElapsedTicks}");
        Console.ReadKey(); 
    }
    private static int[] Task1(String fileName1, String fileName2, String fileName3)
    {
        var task = new Helper();
        var file1 = task.ReadFileAsync(fileName1);
        var file2 = task.ReadFileAsync(fileName2);
        var file3 = task.ReadFileAsync(fileName3); 
        return Task.WhenAll(file1, file2, file3).Result;
    }

    private static int[] Task2()
    { 
        var task = new Helper();
        return task.ReadDirectoryAsync("D:\\Test");
    }


    }