using System.Collections.Generic;

namespace CodingDojo3.Example3
{
    public class NestingIfs
    {
        private Dictionary<string, List<int>> someDic;

        public int DoSomethingWithTheString(string theString)
        {
            int sum = 0;
            if (someDic.ContainsKey(theString))
            {
                List<int> theInt = someDic[theString];
                if (someDic[theString] != null)
                {
                    foreach (int num in someDic[theString])
                    {
                        sum += num;
                    }

                    return sum;
                }
                else
                {
                    return sum;
                }
            }
            else
            {
                return sum;
            }
        }
        
        //VS

        public int DoSomethingCleanWithTheString(string theString)
        {
            if (!someDic.ContainsKey(theString) || someDic[theString] == null)
            {
                return 0;
            }

            int sum = 0;
            foreach (int num in someDic[theString])
            {
                sum += num;
            }

            return sum;
        }
    }
}