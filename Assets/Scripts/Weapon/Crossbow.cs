using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(bolt, shootPoint.position, shootPoint.rotation);
    }
}
