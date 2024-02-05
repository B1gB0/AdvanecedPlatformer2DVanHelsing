using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityPlaceLogic : ScriptableObject
{
    [SerializeField] protected RangeAbillity RangeAbility;

    public abstract List<Enemy> TryGetEnemies(Collider2D collider2D);
}
