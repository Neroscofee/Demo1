using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Demo1.Interface
{
    class Mage : Role
    {
        public void CastSkill()
        {
            Trace.WriteLine("法师使用寒冰箭");
        }
    }
}
