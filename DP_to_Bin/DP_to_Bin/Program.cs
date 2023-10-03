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
            // Creo un array di bool di lunghezza 32 per rappresentare l'indirizzo IP in binario
            bool[] boolIP = new bool[32];
            int index = 0;

            // Itero su ciascun ottetto dell'indirizzo IP
            foreach (int octet in dp)
            {
                // Converto ciascun ottetto in rappresentazione binaria a 8 bit
                for (int i = 7; i >= 0; i--)
                {
                    // Utilizzo operazioni bit a bit per ottenere ciascun bit dell'ottetto
                    // e memorizzalo nell'array di bool
                    boolIP[index] = (octet & (1 << i)) != 0;
                    index++;
                }
            }

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
            int[] dottetPuntation = new int[4];

            dottetPuntation = GetOctet();

            bool[] binaryIP = new bool[32];

            binaryIP = 

            // Stampa l'indirizzo IP binario
            Console.WriteLine("Indirizzo IP binario:");
            for (int i = 0; i < dottetPuntation.Length; i++)
            {
                Console.Write(dottetPuntation[i] ? "1" : "0");
                if ((i + 1) % 8 == 0)
                    Console.Write(" "); // Spazio ogni 8 bit per facilitare la lettura
            }





            PrintIP(dottetPuntation);

            Console.ReadKey();

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

        static void PrintIP(int[] ip)
        {
            foreach (int octect in ip)
            {
                Console.Write(octect + ".");
            }
        }
    }
}
