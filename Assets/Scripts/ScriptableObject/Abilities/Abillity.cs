using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abillities/New Abillity")]
public class Abillity : ScriptableObject
{
    //[SerializeField] private AbilityPlaceLogic _placeLogic;
    [SerializeField] private AbillityAction _abillityAction;

    public AbillityAction AbillityAction => _abillityAction;

    public void ApplyAction(List<Enemy> enemies, Player player)
    {
        foreach (var enemy in enemies)
        {
            _abillityAction.Action(enemy, player);
        }
    }
}
