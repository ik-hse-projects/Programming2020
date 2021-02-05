using System;
using System.Collections.Generic;
using System.Linq;

internal class MyGiveawayHelper
{
    private int number;
    private List<string> logins;
    private List<string> prizes;

    public MyGiveawayHelper(string[] logins, string[] prizes)
    {
        number = 1579;
        this.logins = logins.ToList();
        this.prizes = prizes.ToList();
    }

    public bool HasPrizes => prizes.Count != 0;

    public (string prize,string login) GetPrizeLogin()
    {
        number *= number;
        number /= 100;
        number %= 10000;

        var idx = number % logins.Count;
        var login = logins[idx];

        var prize = prizes[0];
        prizes.RemoveAt(0);

        return (prize, login);
    }
}