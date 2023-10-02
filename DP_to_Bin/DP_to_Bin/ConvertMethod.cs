using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_to_Bin
{
    public interface ConvertMethod
    {
        bool[] Convert_DP_to_Bin(int[] dp);
        int Convert_DP_to_Int(int[] dp);
        int Convert_Bin_to_Int(bool[] bn);
        int[] Convert_Bin_to_DP(bool[] b);
    }
}
