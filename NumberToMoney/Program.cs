using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToMoney {
    class Program {
        static void Main(string[] args) {
            Solution s = new Solution();
            int[] tests = new int[] { 1, 10, 100, 1000, 10 * 1000, 1000 * 1000, 1000 * 1000 * 1000, 123456, 1000001, 1111111111, 0, 1, 19, 20, 21, 99, 101, 119, 120, 121, 1019, 202, 2202, int.MaxValue};

            foreach(int value in tests) {
                Console.WriteLine("{0:n0}: {1}", value, s.GetMoneyString(value));
            }
        }
    }

    public class Solution {

	/*
	one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen sixteen seventeen eighteen nineteen 
	twenty twentyone twentytwo twentythree twentyfour twentyfive twentysix twentyseven twentyeight twentynine thirty thirtyone 
	thirtytwo thirtythree thirtyfour thirtyfive thirtysix thirtyseven thirtyeight thirtynine fourty fourtyone fourtytwo fourtythree 
	fourtyfive fourtysix fourtyseven fourtyeight fourtynine fifty fiftyone fiftytwo fiftythree fiftyfour fiftyfive fiftysix fiftyseven 
	fiftyeight fiftynine sixty sixtyone sixty wo sixtythree sixtyfour sixtyfive sixtysix sixtyseven sixtyeight sixtynine seventy seventyone 
	seventytwo seventythree seventyfour seventyfive seventysix seventyseven seventyeight seventynine eighty eightyone eightytwo eightythree 
	eightyfour eightyfive eightysix eightyseven eightyeight eightynine ninety ninteyone ninteytwo ninteythree ninteyfour ninteyfive 
	ninteysix ninteyseven ninteyeight ninteynine onehundred 
	*/
        public string[] KnownSmallNumbers = new string[] {
            "",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six", 
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen",
        };

		public string[] KnownTenTimeNumbers = new string[] {
            "",
            "",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty", 
            "seventy",
            "eighty",
            "ninety"
        };

        public string[] KnownThousandTimeNumbers = new string[] {
            "thousand",
            "million",
            "billion"
        };

        public string GetMoneyString(int value) {
			string result = string.Empty;
			int kNumber = -1;
			
            // edge: 1000; 1000,000; 10,000; 123,456; 1,000,001
			while (value != 0){
				int rest = value % 1000;
				value = value / 1000;
				
                if (rest != 0) {

                    string subResult = GetThreeDigitMoneyString(rest);

                    if (kNumber == -1) {
                        result = subResult;
                    }
                    else {
                        result = subResult + " " + KnownThousandTimeNumbers[kNumber] + (rest > 1 ? "s" : string.Empty) + " " + result;
                    }                    
                }

				kNumber++;
			}

            return result;
        }

        private string GetThreeDigitMoneyString(int value) {
            if (value >= 1000) {
                throw new ArgumentException("parameter value expected to be less than 1000.", "value");
            }

			//handle the hundred number
			int hundred = value / 100;
			string result = string.Empty;

			if (hundred > 0){
				result += KnownSmallNumbers[hundred] + (hundred == 1 ? " hundred" : " hundreds");
			}
			
			int rest = value % 100;
			
			// edge cases: 0, 1, 100, 19, 20, 21, 99, 101, 119, 120, 121
			if (rest > 0) {

                if (result != string.Empty) {
                    result += " ";
                }

				if (rest <= 19) { // handle small 2-digit number together, say 19
					result += KnownSmallNumbers[rest];
				} else { // handle big 2-digit number. say 20, 21
					int tenNum = rest / 10;
					rest = rest % 10;

					result += KnownTenTimeNumbers[tenNum];
					
					if (rest != 0){
                        result += " " + KnownSmallNumbers[rest];
					}
				}
			}
			
			return result;
        }
    }
}
