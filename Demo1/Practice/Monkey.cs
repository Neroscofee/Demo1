using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Demo1.Practice
{
    class Monkey:Animal
    {
        public void LikeFood()
        {
            Trace.WriteLine("我是猴子，我喜欢吃桃子");
        }
    }
}
