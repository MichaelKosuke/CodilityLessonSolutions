using System;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

// By MichaelKosuke@github
// http://github.com/MichaelKosuke
// Correctness 100% Performance 100% (100%) The solution obtained perfect score.
// Complexity O(N) or O(N*log(N))
// 03 May 2023

class Solution {
    public int solution(int[] A) {
        if (A.Length == 0)
            return 0;

        if (A.Length == 1)
            return A[0];

        Array.Sort(A);
        int count = 1;
        for (int i = 0; i < A.Length; i++){
            if (i == 0) {
                continue;
            }

            if (A[i] == A[i-1]){
                count++;
            }
            else if (count % 2 == 1){
                return A[i-1];
            }
            else{
                count = 1;
            }
        }
        return A[A.Length - 1];
    }
}
