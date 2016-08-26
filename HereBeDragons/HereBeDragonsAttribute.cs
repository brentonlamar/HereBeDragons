using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HereBeDragons
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HereBeDragonsAttribute : Attribute
    {
        public DragonType DragonType;
        public string Comment;
        public HereBeDragonsAttribute(DragonType dragonType, string comment)
        {
            DragonType = dragonType;
            Comment = comment;
        }
    }
}
