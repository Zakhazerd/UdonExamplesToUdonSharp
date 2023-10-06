
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;


public class SyncedSlider : UdonSharpBehaviour
{
    public Slider uiSlider;
    public Text uiText;
    [UdonSynced, FieldChangeCallback(nameof(SliderValue))]
    private float sliderValue = 0;
   
    public void OnValueChanged()
    {
        if(SliderValue != uiSlider.value)
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            SliderValue = uiSlider.value;
            RequestSerialization();
        }
    }

    public float SliderValue
    {
        set
        {
            sliderValue = value;
            uiText.text = sliderValue.ToString();
            uiSlider.value = sliderValue;
        }
        get => sliderValue;
    }
}
