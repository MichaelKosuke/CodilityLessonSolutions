using System;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

// By MichaelKosuke@github
// https://github.com/MichaelKosuke
// Correctness 100% Performance 80% (88%)
// Complexity O(N+M)

class Solution {
    public int[] solution(int N, int[] A) {
        int n = A.Length;
        int[] result = new int[N];
        int maxval = 0;
        bool justmax = true; // if previous operation was MaxCounter then dont need to MaxCounter twice in a row
        bool goingtomax = false; // for [MaxCounter, Increase(X), MaxCounter] case
        for (int i = 0; i < n; i++)
        {
            if (A[i] <= N)
            {
                result[A[i] - 1] += 1;
                justmax = false;
                if (goingtomax) 
                {
                    maxval++; 
                }
                else
                {
                    if (result[A[i] - 1] > maxval)
                        maxval = result[A[i] - 1];
                }
            }
            else if (!justmax) // current Operation is MaxCounter, if previous Operation is MaxCounter do nothing
			{
				// [MaxCounter, Increase(X), MaxCounter] case, but only apply if there's 2 more Operation after current one
				if (i + 2 > n - 1 || (i + 2 <= n - 1 && A[i + 2] != N+1))
				{
					goingtomax = false; // there's no MaxCounter in next 2 Operation
					for (int j = 0; j < N; j++)
					{
						result[j] = maxval;
					}
					justmax = true;
				}
				else
				{
					goingtomax = true;
				}
			}
        }
        return result;
    }
}