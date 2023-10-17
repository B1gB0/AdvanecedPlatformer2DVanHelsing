using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    public void OnCgangedValue(float value, float maxValue)
    {
        Slider.value = value / maxValue;
    }
}
