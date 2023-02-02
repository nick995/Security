using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    internal class Class1
    {
        public static int prevIndex = 0;

        public static Dictionary<string, int> charGCD = new Dictionary<string, int>(26);

        //public static Dictionary<char, List<char>> dividedCipher = new Dictionary<char, List<char>>();

        public static List<List<char>> dividedCipher;
                
        //public static string cipherWord = "aabbaabbbaa";
        public static string cipherWord = "ELFMASBQDXISZMNMHIBFEFQIMEUVNGLML" +
    "RETHAZAQPPDOTEGDEDONLYVZJNWHCKBLPPQWDQZZGFFUKD" +
    "WCIXWPZKKSIDYBGBATBUMOWFMYGFBPKYVELFHRHBMDMESJL" +
    "QMZVHSXMCPDIOWKJKLOVFGOWCBSIOOPAYVDEZWJYKORVFGOA" +
    "YVHMMZJGDAEEORWYKQYWUYQOKQEXISZMNMCIUINFCBZLJGWHK" +
    "ZEQFBPORMCIVDKFOVEISWJYKVOGMCOAXOELFRKGBPPMTDNGWX" +
    "EPZUNSLJPHCMPOYUPRXVKXYZNIIWIAXBZXISXSDPCSPAWFNA" +
    "SSWSDACPPEEWJLRMESJZALDPPCESISXLXSOSUGGMOXPXWUUQP" +
    "XSSAZYZYWBMEFQBSEUHDWNCOITKEXOJFROMYDKQXIEVAOKARSP" +
    "RBGBQEFFTKJOWYIPTPZOBSYHGQJSVLXFGKFDPPHVRAKBCRWBME" +
    "FQMGISHDMCBZHFOZTOIEWMSXGGAVMCSSAVLPVFRPZOLFHFQKFF" +
    "QYGFGPZOUELBHPZOGSEWSPZOECSOULWBAZRBGDWSAYXNONJSMO" +
    "EORYSXBASTGETVGASTGAKCBSIBAKMXBZJNCJWIBSIZOOCPWCPPCG" +
    "AXOLVPIJVDPPJJFOLDPFKSSWDSHPWUVAQRIGINOZWKUTWUOGWKV" +
    "OQVGPZKDPXISSJYVRPFPKOCSTVFUWJNTPWTHDWIJCIBYKFOWQLJG" +
    "XSDPCSPAPAVMDFFTKJOTPEWWJYDPPHVRAUKTWWBTPWBBSINGWQS" +
    "VREUZASCBTENVKMCMMVPYAFDPPHVRAEOMEWVDSADPSMTPKOVQYKU" +
    "SWEKBELFZKUKTLPMSUSXLEEMYOLYBSINOXGEBSMTJEGVMYXFBYGEV" +
    "EISKWDDMCWPPYZKSCIBQPKGQELBBCWBIYHWSJYOIYGFCJZSAXMORKX" +
    "DMYWQSWCSVRSGVEKDQXITSNNOLTRWWALXIXXPFADKBPXPHDWSADYFG" +
    "HGGETXUSZLRMZHPFAVYVLPERKFXGVISOXSDAZWPTPWXMYXFFEFQKZR" +
    "WSNKKBTSOGDSVNHEZHDJYCRLQWLWCQYFVHEKZZZQQHHQDWWHZCQSBM" +
    "ZYUCBQYCCIMSIWXBMCXOHLOZ";

        public static void Main(string[] args)
        {

            Kasiski(cipherWord);

            foreach(var val in charGCD)
            {
                if (val.Value < 3 || val.Key.Length <3)
                {
                    charGCD.Remove(val.Key);
                }
            }
            //sorting dictionary.
            var sortedDic = from entry in charGCD orderby entry.Value ascending select entry;

            //foreach (var kvp in sortedDic)
            //{
            //    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            //}

            //==================================FINDING KEY LENGTH END=============================================

            DivideCipher(cipherWord, 8);

            Console.WriteLine();

        }

        public static void DivideCipher(string cipherWord, int keyLength)
        {
            dividedCipher = new List<List<char>>(keyLength);

            for(int j=0; j<keyLength; j++)
            {
                dividedCipher.Add(new List<char>());
            }

            for (int i=0; i<cipherWord.Length; i++)
            {
                dividedCipher[i%keyLength].Add(cipherWord[i]);
            }
        }

        public static void Kasiski(string cipher)
        {

            StringBuilder searchWord =new StringBuilder();

            bool flag = false; 


            for (int k = 0; k < cipher.Length; k++)
            {
                flag = false;
                for (int i = k; i < cipher.Length; i++)
                {
                    searchWord.Append(cipher[i]);

                    for (int j = i + searchWord.Length; j < cipher.Length; j++)
                    {
                        searchWord.Append(cipher[j]);

                        if (FindIndex(cipherWord, searchWord.ToString()))
                        {

                        }
                        else
                        {
                            searchWord.Clear();
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                } 
            }
        }

        //https://www.geeksforgeeks.org/find-indices-of-all-occurrence-of-one-string-in-other/

        public static bool FindIndex(string str1, string str2)
        {
            bool flag = false;
            //set up as first index.
            int prevIndex = str1.IndexOf(str2);

            for(int i=str1.IndexOf(str2)+1; i< str1.Length - str2.Length +1; i++)
            {
                //if there's same word in chiper.
                if(str1.Substring(i, str2.Length).Equals(str2))
                {                    
                    //set up flag as true.
                    flag = true;

                    // it's gonna be starting point.
                    if (!charGCD.ContainsKey(str2))
                    {
                        charGCD[str2] = -1;
                    }
                    else
                    { 
                        //Console.WriteLine("current word = " + str2 + "     current index = " + i + " prevIndex = " + prevIndex);
                        
                        charGCD[str2] = FindGCD(charGCD[str2], i-prevIndex);          

                    }

                    prevIndex = i;

                }

            }
            return flag;
        }

        public static int FindGCD(int a, int b)
        {
            if (a > 0)
            {
                while (a != 0 && b != 0)
                {
                    if (a > b)
                        a %= b;
                    else
                        b %= a;
                }
                return a == 0 ? b : a;
            }
            else
            {
                return b;
            }
        }

    }
}
