using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Demo1.Interface
{
    class Rogue : Role
    {
        public void CastSkill()
        {
            Trace.WriteLine("盗贼使用毁伤");
        }
    }
}
