using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auto.NuGetServer.Test.Component;

namespace Auto.NuGetServer.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string str=JsonHelper.ToJson(new {Id = 1, Name = "zhangsan"});

            System.Console.WriteLine(str);

            System.Console.ReadKey();
        }
    }
}
