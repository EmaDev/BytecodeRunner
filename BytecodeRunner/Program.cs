using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BytecodeRunner
{    
    class Program
    {
        static void Main(string[] args)
        {
            //byte[] bytes = BitConverter.GetBytes((Int32)2208);
            try
            {
                Runner runner = new Runner(args);
                runner.load();
                runner.run();
            }
            catch (RunnerError re)
            {
                Console.WriteLine(re.Message);
            }
            Console.ReadKey();
        }
    }
}
