using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HereBeDragons
{
    public class DragonReport
    {
        public static void Generate(Assembly assembly, string outputLocation)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("===========================");
            stringBuilder.AppendLine($"Report date: {DateTime.UtcNow}");

            var countOfDragons = 0;

            foreach (var dragonType in GetTypesWithDragonAttribute(assembly))
            {
                countOfDragons++;
                var attribute = System.Attribute.GetCustomAttributes(dragonType).First() as HereBeDragonsAttribute;

                stringBuilder.AppendLine($"Class: {dragonType.FullName}");
                stringBuilder.AppendLine($"Type: {attribute.DragonType}");
                stringBuilder.AppendLine($"Comment: {attribute.Comment}");
                stringBuilder.AppendLine(string.Empty);
                stringBuilder.AppendLine("************************");
            }

            foreach (var dragonMethodInfo in GetMethodsWithDragonAttribute(assembly))
            {
                countOfDragons++;
                var attribute = System.Attribute.GetCustomAttributes(dragonMethodInfo).First() as HereBeDragonsAttribute;

                stringBuilder.AppendLine($"Method: {dragonMethodInfo.DeclaringType.FullName}.{dragonMethodInfo.Name}");
                stringBuilder.AppendLine($"Type: {attribute.DragonType}");
                stringBuilder.AppendLine($"Comment: {attribute.Comment}");
                stringBuilder.AppendLine(string.Empty);
                stringBuilder.AppendLine("************************");
            }


            stringBuilder.AppendLine($"Total Dragons found: {countOfDragons}");
            stringBuilder.AppendLine("===========================");

            System.IO.File.WriteAllText(outputLocation, stringBuilder.ToString());
        }

        private static IEnumerable<MethodInfo> GetMethodsWithDragonAttribute(Assembly assembly)
        {
            foreach (var method in assembly.GetTypes().SelectMany(t => t.GetMethods()))
            {
                if (method.GetCustomAttributes(typeof(HereBeDragonsAttribute), false).Length > 0)
                {
                    yield return method;
                }
            }
        }
        private static IEnumerable<Type> GetTypesWithDragonAttribute(Assembly assembly)
        {
            foreach (var classType in assembly.GetTypes())
            {
                if (classType.GetCustomAttributes(typeof (HereBeDragonsAttribute), true).Length > 0)
                {
                    yield return classType;
                }
            }
        }
    }
}
