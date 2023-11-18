using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    public class Helper
    {
        public async Task<int> ReadFileAsync(String fileName)
        {
            int spaces = 0;
            using (var sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    spaces += line.Count(Char.IsWhiteSpace);
                }
            }
            return spaces;
        }

        public int[] ReadDirectoryAsync(String directoryName)
        {
            var files = Directory.GetFiles(directoryName);
            var tasks = new List<Task<int>>();
            foreach (var file in files)
            {
                tasks.Add(ReadFileAsync(file));
            }
            return Task.WhenAll(tasks).Result; 
        }
          
    }
}
