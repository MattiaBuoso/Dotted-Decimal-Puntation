using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DP_to_Bin
{
    internal class Program
    {
        //Author: Buoso Mattia 4E

        static void Main(string[] args)
        {
            string address;
            int[] dottedPuntation = new int[4]; 
            int intAddressFromDP = 0;
            int intAddressFromBin = 0;
            int[] dottedDecimalFromBin;

            Console.WriteLine("Insert the IP address:\n");
            address = Console.ReadLine();

            dottedPuntation = GetOctet(address);

            bool[] binaryIP = new bool[32];

            binaryIP = Convert_DP_to_Bin(dottedPuntation);

            intAddressFromDP = Convert_DP_to_Int(dottedPuntation);

            intAddressFromBin = Convert_Bin_to_Int(binaryIP);


            Console.WriteLine("Decimal IP from a Dotted: " + intAddressFromDP);

            Console.WriteLine("Decimal IP from a Binary: " + intAddressFromBin);

            Console.WriteLine("Dotted Decimal IP from Binary: ");
            dottedDecimalFromBin = Convert_Bin_to_DP(binaryIP);

            foreach (var octect in dottedDecimalFromBin) 
            {
                Console.Write(octect.ToString() + ' ');
            }

            Console.ReadKey();
        }

        static int[] GetOctet(string address)
        {
            string[] octetStrings = address.Split('.');
            int[] ip = new int[4];

            if (octetStrings.Length != 4)
            {
                throw new ArgumentException("Invalid IP address format. The address should have 4 octets.");
            }

            for (int i = 0; i < octetStrings.Length; i++)
            {
                if (!int.TryParse(octetStrings[i], out ip[i]))
                {
                    throw new ArgumentException("Invalid octet value. Octet should be a valid integer between 0 and 255.");
                }

                if (ip[i] < 0 || ip[i] > 255)
                {
                    throw new ArgumentException("Invalid octet value. Octet should be a valid integer between 0 and 255.");
                }
            }

            return ip;
        }

         static bool[] Convert_DP_to_Bin(int[] dp)
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
                    // Utilizzo un' operazione bit a bit per ottenere ciascun bit dell'ottetto
                    // e memorizzalo nell'array di bool
                    boolIP[index] = (octet & (1 << i)) != 0; // << operatore di leftshift per 'i'
                    index++;
                }
            }

            return boolIP;
        }

        static int Convert_DP_to_Int(int[] dp)
        {
            int result = 0;
 
            // Calcolo il risultato come l'elevamento a potenza dei quattro ottetti in serie
            for (int i = 0; i < 4; i++)
            {
                result += dp[i] * (int)Math.Pow(256, 3 - i); //converto esplicitamente perche' mathpow restituisce double
            }

            return result & 0x7FFFFFFF;  // Garantisce che il risultato sia positivo 
        }

        static int Convert_Bin_to_Int(bool[] bn)
        {
            int result = 0;

            for (int i = bn.Length - 1; i >= 0; i--)
            {
                if (bn[i])
                {
                    // Se il bit è vero (1), aggiungi la potenza di 2 corrispondente
                    result += (int)Math.Pow(2, bn.Length - 1 - i);
                }
            }

            return result & 0x7FFFFFFF;  // Garantisce che il risultato sia positivo (operazione di AND dove 0x7FFFFFFF rappresenta il massimo valore positivo)
        }

        static int[] Convert_Bin_to_DP(bool[] b)
        {
            int index = 0;
            int[] dottedDecimalArray = new int[4];

            for (int i = 0;i<b.Length; i+= 8) //divido in gruppi da 8
            {
                int octectValue = 0;

                for (int j = 0; j < 8; j++) 
                {
                    octectValue += (b[i + j] ? 1 : 0) << (7 - j); // sposta il bit al suo posizionamento corretto nell'ottetto. Se il bit è true (1), lo sposta nella posizione corretta (da sinistra verso destra) e lo aggiunge all'octetValue.
                }

                dottedDecimalArray[index] = octectValue;
                index++;
            }


            return dottedDecimalArray;
        }
    }
}
