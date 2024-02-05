using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abillities/Place Logic/Near Enemy")]
public class AbilityPlaceLogicNearEnemy : AbilityPlaceLogic
{
    public override List<Enemy> TryGetEnemies(Collider2D rangeAbillity)
    {
        if(rangeAbillity.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            return new List<Enemy>() { enemy };
        }

        return null;
    }
}
