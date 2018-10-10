using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMiniGameBonus
{
    float BonusValue { get; }
    void Destroy();
}