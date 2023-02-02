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

        public static Dictionary<char, double> _chiSquare = new Dictionary<char, double>();
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

        public static Dictionary<string, double> frequency = new Dictionary<string, double>
        {
            { "A", 0.08167 },
            {"B", .01492 },
            {"C", .02782},
            {"D", .04253},
            {"E", .12702},
            {"F", .02228},
            {"G", .02015},
            {"H", .06094},
            {"I", .06966},
            {"J", .00153},
            {"K", .00772},
            {"L", .04025},
            {"M", .02406},
            {"N", .06749},
            {"O", .07507},
            {"P", .01929},
            {"Q", .00095},
            {"R", .05987},
            {"S", .06327},
            {"T", .09056},
            {"U", .02758},
            {"V", .00978},
            {"W", .02360},
            {"X", .00150},
            {"Y", .01974},
            { "Z", .00074}
        };

        public static List<double> calculatedFrequency = new List<double>();


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

            //==================================FINDING KEY LENGTH END=============================================

            DivideCipher(cipherWord, 8);

            ChiSquareTest();

          


        }

        public static void DivideCipher(string cipherWord, int keyLength)
        {
            dividedCipher = new List<List<char>>(keyLength);
            //initialize
            for(int j=0; j<keyLength; j++)
            {
                dividedCipher.Add(new List<char>());
            }
            //divide 
            for (int i=0; i<cipherWord.Length; i++)
            {
                dividedCipher[i%keyLength].Add(cipherWord[i]);
            }
        }

        public static void ChiSquareTest()
        {

            double frequencySum = 0;

            int ascii = 0;

            int convertedAscii = 0;

            char convertedChar = ' ';

            char observedCount = ' ';

            int colLength = 0;

            double expectedCount = 0;

            double xSquare = 0;

            Dictionary<char, double> temp = new Dictionary<char, double>();


            //dividedCipher = divided by key length list.
            for (int i=0; i<dividedCipher.Count; i++)
            {   //apply all of alphabets
                for (int k = 0; k < 26; k++)
                {   //check through all lists
                    for (int j = 0; j < dividedCipher[i].Count; j++)
                    {
                        //convert character to ascii
                        ascii = (int)dividedCipher[i][j];
                        //apply the convert number
                        convertedAscii = ascii + k;
                        
                        //if ascii is over the range
                        if(convertedAscii> 90)
                        {
                            convertedAscii = convertedAscii - 26;
                        }
                        else
                        {
                            convertedChar = (char)convertedAscii;
                        }

                        if (!_chiSquare.ContainsKey(convertedChar))
                        {
                            _chiSquare.Add(convertedChar, 1);
                        }
                        else
                        {
                            _chiSquare[convertedChar]++;
                        }


                    }//check through all lists end


                    //calcualte the xSquare and sum all of them
                    foreach (var kvp in _chiSquare)
                    {
                        expectedCount = frequency[kvp.Key.ToString()] * _chiSquare.Sum(x => x.Value);
                        //Console.WriteLine(kvp.Key + "     " + kvp.Value + "      " + _chiSquare.Sum(x => x.Value));
                        xSquare += Math.Pow(kvp.Value - expectedCount,2) / expectedCount;
                        //Console.WriteLine(xSquare);
                    }

                    temp.Add((char)(k + 65), xSquare);

                    //reset
                    xSquare = 0;
                    _chiSquare.Clear();

                    
                }//applying alphabets are done.
                 //at this point, _chiSquare contains the number of characters.

                var sortedDict = from entry in temp orderby entry.Value ascending select entry;

                foreach (var kvp in sortedDict)
                {
                    Console.WriteLine(kvp.Key + "     " + kvp.Value);
                }
                Console.WriteLine("============================================================================");

                temp.Clear();


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
