partial class Program
{
    static int Count(int[] arr, int k)
    {
        var res = 0;
        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = i+1; j < arr.Length; j++)
            {
                if (arr[i] + arr[j] == k)
                {
                    res++;
                }
            }
        }

        return res;
    }
}
