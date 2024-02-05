using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbillityAction : ScriptableObject
{
    [SerializeField] private int _duration;

    public int Duration => _duration;

    public abstract void Action(Enemy enemy, Player player);
}
