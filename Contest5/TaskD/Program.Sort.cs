using System;
using System.Collections.Generic;

public partial class Program
{
    static bool ParseArrayFromLine(string line, out int[] arr)
    {
        var numbers = line.Split(" ");
        arr = new int[numbers.Length];
        for (var i = 0; i < numbers.Length; i++)
        {
            var number = numbers[i];
            if (!int.TryParse(number, out arr[i]))
            {
                return false;
            }
        }

        return true;
    }

    private static void Merge(int[] arr, int start, int end, int mid)
    {
        var sorted = new int[end - start];
        var left = start;
        var right = mid;
        for (int i = 0; i < sorted.Length; i++)
        {
            if (right >= end)
            {
                sorted[i] = arr[left++];
            }
            else if (left >= mid)
            {
                sorted[i] = arr[right++];
            }
            else if (arr[left] < arr[right])
            {
                sorted[i] = arr[left++];
            }
            else
            {
                sorted[i] = arr[right++];
            }
        }
        
        Array.Copy(sorted, 0, arr, start, sorted.Length);
        //sorted.CopyTo(arr, start);
    }
}