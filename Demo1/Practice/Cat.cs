using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Demo1.Practice
{
    class Cat:Animal
    {
        public void LikeFood()
        {
            Trace.WriteLine("我是小猫，我喜欢吃鱼");
        }
    }
}
