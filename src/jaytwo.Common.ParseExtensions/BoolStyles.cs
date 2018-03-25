using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.Common.ParseExtensions
{
    [Flags]
    public enum BoolStyles
    {
        Default = 0,
        TrueFalse = 1,
        TF = 2,
        YesNo = 4,
        YN = 8,
        OneZero = 16,
    }
}
