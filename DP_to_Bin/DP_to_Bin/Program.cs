using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DP_to_Bin
{
    internal class Program : ConvertMethod
    {
        bool[] ConvertMethod.Convert_DP_to_Bin(int[] dp)
        {
            bool[] boolIP = new bool[32];

            return boolIP;
        }

        int ConvertMethod.Convert_DP_to_Int(int[] dp)
        {
            int a = 0;
            return a;
        }

        int ConvertMethod.Convert_Bin_to_Int(bool[] bn)
        {
            int a = 0;  
            return a;
        }

        int[] ConvertMethod.Convert_Bin_to_DP(bool[] b)
        {
            int a = 0;  
            return new int[32];
        }


        static void Main(string[] args)
        {
            int[] ip = new int[4];

            ip = GetOctet();

        }

        static int[] GetOctet()
        {
            int[] ip = new int[4];
            
            for(int i = 0; i<4; i++)
            {
                try
                {
                    ip[i] = Convert.ToByte(Console.ReadLine());
                }
                catch
                {
                    throw new Exception("Invalid Element");
                }
            }

            return ip; 
        }
    }
}
