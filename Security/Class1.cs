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


            //string cipher = "AAABBC";

            Dictionary<char, int> countCharacter = new Dictionary<char, int>(26);

            List<int> list = new List<int>(new int[26]);

            int colValue = 0;

            Kasiski(cipherWord);

            //for (int i=0; i<cipher.Length; i++)
            //{
            //    colValue = char.ToUpper(cipher[i]) - 65;

            //    //if (countCharacter.ContainsKey(cipher[i])) {
            //    //    countCharacter[cipher[i]]++;
            //    //}
            //    //else
            //    //{
            //    //    countCharacter[cipher[i]] = colValue;
            //    //}

            //    if (list[colValue] == null)
            //    {
            //        list[colValue] = 0;
            //    }

            //    list[colValue]++;

            //}

            //int number = 0;

            //for(int i = 0; i < cipher.Length; i++)
            //{
            //    if (!countCharacter.ContainsKey(cipher[i])) {
            //        countCharacter[cipher[i]] = 1;
            //    }
            //    else
            //    {
            //        countCharacter[cipher[i]]++;
            //    }

            //}


            //var sortedDict = from entry in countCharacter orderby entry.Value descending select entry;


            //foreach(KeyValuePair<char, int> entry in sortedDict)
            //{
            //    Console.WriteLine(entry);
            //}

        }

        public static void Kasiski(string cipher)
        {

            StringBuilder searchWord =new StringBuilder();

            bool flag = false; 

            int startingIdx = 0;

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
                            Console.WriteLine(FindIndex(cipherWord, searchWord.ToString()));
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

            for(int i=str1.IndexOf(str2)+1; i<str1.Length - str2.Length +1; i++)
            {
                if(str1.Substring(i, str2.Length).Equals(str2))
                {
                    flag = true;
                    Console.WriteLine(str2 + " at " + i);
                }
            }
            return flag;
        }

    }
}
