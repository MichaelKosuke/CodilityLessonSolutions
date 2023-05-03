using System;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

// By MichaelKosuke@github
// https://github.com/MichaelKosuke
// Correctness 100% Performance 100% (100%)
// Complexity O(N+M)
// 03 May 2023
// https://app.codility.com/demo/results/training7HUDW9-GBE/

class Solution {
    public int[] solution(int N, int[] A) {
        int n = A.Length;
        int[] result = new int[N];
        int prevMaxVal = 0;
        int nextMaxVal = 0;
        bool maxCounterOccurred = false;
        for (int i = 0; i < n; i++)
        {
            if (A[i] <= N) // X <= N 
            {
                if (maxCounterOccurred && result[A[i] - 1] < prevMaxVal)
                {
                    result[A[i] - 1] = prevMaxVal + 1;
                }
                else
                {
                    result[A[i] - 1] += 1;// Increase(X)
                }
                if (result[A[i] - 1] > nextMaxVal)
                    nextMaxVal = result[A[i] - 1]; // set next MaxCounter value
            }
            else // X = N +1
            {
                maxCounterOccurred = true; // MaxCounter()
                prevMaxVal = nextMaxVal;
            }
        }
        
        for (int j = 0; j < result.Length; j++)
        {
            if (maxCounterOccurred && result[j] < prevMaxVal){
                result[j] = prevMaxVal;
            }
        }
        return result;
    }
}