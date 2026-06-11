using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using RangeAttribute = NUnit.Framework.RangeAttribute;

public class ColoringCutomizable : MonoBehaviour
{

    private SpriteRenderer _spr;
    public Slider _sldHUE;
    public Slider _sldSaturation;
    public Slider _sldBrightness;


    void Awake()
    {
        _spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float hue = _sldHUE.value;
        float saturation = _sldSaturation.value;
        float brightness = _sldBrightness.value;

        Color color = Color.HSVToRGB(
            hue, // Matiz
            saturation,  // Saturação
            brightness   // Brilho
        );

        _spr.color = color;
    }



}
