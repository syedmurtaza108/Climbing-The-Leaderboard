using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Climbing_The_Leaderboard
{
    class Program
    {
        static int rank = 1;
        static void Main(string[] args)
        {
            int scoresCount = int.Parse(Console.ReadLine());
            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => int.Parse(aTemp));

            int aliceCount = int.Parse(Console.ReadLine());
            int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => int.Parse(aTemp));

            int[] result = ClimbingLeaderBoard(scores, alice);
            Console.WriteLine(String.Join("\n", result));
        }

        static int[] ClimbingLeaderBoard(int[] scores, int[] alice)
        {
            int[] ans = new int[alice.Length];
            List<int> ranks = GetRanks(scores);
            for (int i = 0; i < alice.Length; i++)
            {
                if(alice[i] < scores.Min())
                {
                    ans[i] = ++rank;
                    continue;
                }
                for (int j = 0; j < scores.Length; j++)
                {
                    if(alice[i] >= scores[j])
                    {
                        ans[i] = ranks[j];
                        break;
                    }
                    
                }
            }
            return ans;
        }



        static List<int> GetRanks(int[] scores)
        {
            
            List<int> ranks = new List<int>();
            ranks.Add(rank);
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] != scores[i - 1])
                {
                    ranks.Add(++rank);
                }
                else
                    ranks.Add(ranks[i-1]);
            }
            return ranks;
        }
    }
}
