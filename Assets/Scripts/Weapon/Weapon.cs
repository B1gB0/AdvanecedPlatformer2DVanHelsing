using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;

    [SerializeField] protected Bolt bolt;

    public abstract void Shoot(Transform shootPoint);
}
