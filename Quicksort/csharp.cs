using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] arr = new int[9999999];
        Random rand = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rand.Next(0, 9999999);
        }

        Stopwatch stopwatch = Stopwatch.StartNew();
        Quicksort(arr, 0, arr.Length - 1);
        stopwatch.Stop();

        long duration = stopwatch.ElapsedMilliseconds;
        Console.WriteLine($"Time : {duration} ms");
    }

    static void Quicksort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right);
            Quicksort(arr, left, pivotIndex - 1);
            Quicksort(arr, pivotIndex + 1, right);
        }
    }

    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[(left + right) / 2];
        while (left <= right)
        {
            while (arr[left] < pivot)
            {
                left++;
            }
            while (arr[right] > pivot)
            {
                right--;
            }
            if (left <= right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }
        }
        return left;
    }
}
