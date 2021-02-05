using System;
using System.Text;

public class Snowflake
{
    private int widthAndHeight;
    private int raysCount { get; set; }

    private static int NumberOfSetBits(int i)
    {
        // https://stackoverflow.com/a/12175897
        i = i - ((i >> 1) & 0x55555555);
        i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
        return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
    }

    public Snowflake(int widthAndHeight, int raysCount)
    {
        if (widthAndHeight % 2 == 0)
        {
            throw new ArgumentException("Incorrect input");
        }

        if (raysCount == 1 || raysCount == 2 || NumberOfSetBits(raysCount) != 1)
        {
            throw new ArgumentException("Incorrect input");
        }

        this.widthAndHeight = widthAndHeight;
        this.raysCount = raysCount;
        this.result = Render();
    }

    private static bool TrySet(char[,] canvas, int x, int y)
    {
        if (x < 0 || x >= canvas.GetLength(0))
        {
            return false;
        }

        if (y < 0 || y >= canvas.GetLength(1))
        {
            return false;
        }

        canvas[x, y] = '*';
        return true;
    }

    private static void DrawCross(char[,] canvas, int x, int y, int flags)
    {
        // Top-left
        if ((flags & 0b1000) != 0)
        {
            int i = 0;
            while (TrySet(canvas, x - i, y - i))
            {
                i++;
            }
        }

        // Top-right
        if ((flags & 0b0100) != 0)
        {
            int i = 0;
            while (TrySet(canvas, x + i, y - i))
            {
                i++;
            }
        }

        // Bottom-right
        if ((flags & 0b0010) != 0)
        {
            int i = 0;
            while (TrySet(canvas, x + i, y + i))
            {
                i++;
            }
        }

        // Bottom-left
        if ((flags & 0b0001) != 0)
        {
            int i = 0;
            while (TrySet(canvas, x - i, y + i))
            {
                i++;
            }
        }
    }

    private string result;

    private string Render()
    {
        var raysCount = this.raysCount;
        
        var canvas = new char[widthAndHeight, widthAndHeight];
        for (int i = 0; i < widthAndHeight; i++)
        {
            for (int j = 0; j < widthAndHeight; j++)
            {
                canvas[i, j] = ' ';
            }
        }

        var center = widthAndHeight / 2;
        for (int i = 0; i < widthAndHeight; i++)
        {
            canvas[center, i] = '*';
            canvas[i, center] = '*';
        }

        for (int i = 0; i <= center; i += 2)
        {
            if (raysCount <= 0)
            {
                break;
            }
            var a = center - i;
            var b = center + i;
            // Left
            DrawCross(canvas, a, center, 0b1001);
            // Right
            DrawCross(canvas, b, center, 0b0110);
            // Top
            DrawCross(canvas, center, a, 0b1100);
            // Bottom
            DrawCross(canvas, center, b, 0b0011);
            raysCount -= 4;
            
        }

        var result = new StringBuilder();
        for (int i = 0; i < widthAndHeight; i++)
        {
            result.Append(canvas[i, 0]);

            for (int j = 1; j < widthAndHeight; j++)
            {
                result.Append(' ').Append(canvas[i, j]);
            }

            result.AppendLine();
        }

        return result.ToString();
    }

    public override string ToString()
    {
        return result;
    }
}