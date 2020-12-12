using System;

public static class GiftCreator
{
    public static Gift CreateGift(string giftName)
    {
        return giftName switch
        {
            "Phone" => new Phone(),
            "PlayStation" => new PlayStation(),
            _ => throw new ArgumentException("Incorrect input")
        };
    }
}

public class Phone : Gift
{
    private static int count = 0;

    public Phone() : base(count++)
    {
    }
}

public class PlayStation : Gift
{
    private static int count = 0;

    public PlayStation() : base(count++)
    {
    }
}