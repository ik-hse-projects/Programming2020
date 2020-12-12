using System;

class Soldier
{
    public virtual string Attack() => "Shoot from gun";
}

class CoolerSoldier : Soldier
{
    public override string Attack() => "Shoot from gun and throw a grenade";
}

class ManInBlack : Soldier
{
    public new virtual string Attack() => "Shoot from blaster";
}

class ManInBlackBoss : ManInBlack
{
    public override string Attack() => "Shoot from blaster and call an army of aliens";
}