using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abillities/Actions/Absorption Health")]
public class AbsorptionHealthAction : AbillityAction
{
    [SerializeField] private float _quantityHealth;

    public override void Action(Enemy enemy, Player player)
    {   
        enemy.ApplyDamage(_quantityHealth);
        player.AddHealth(_quantityHealth);
    }
}
