using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoints : IBonus
{
    public void Bonus(Model h)
    {
        h.score++;
    }
}
