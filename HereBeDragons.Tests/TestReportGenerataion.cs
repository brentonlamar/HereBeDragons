using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HereBeDragons.Tests
{
    
    public class TestReportGenerataion
    {
        [Test]
        public void GenerateAReport()
        {
            HereBeDragons.DragonReport.Generate(Assembly.GetExecutingAssembly(), @"C:\Temp\DragonReport");
        }
    }
}
