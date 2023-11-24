using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider SmoothSlider;
    [SerializeField] protected Slider Slider;
    [SerializeField] protected Text Text;

    protected float MaxValue;

    public void OnCgangedValue(float currentValue, float maxValue, float targetValue)
    {
        SmoothSlider.value = currentValue / maxValue;
        Slider.value = targetValue / maxValue;
        Text.text = ((int)targetValue).ToString() + "/" + ((int)maxValue).ToString();
    }
}
