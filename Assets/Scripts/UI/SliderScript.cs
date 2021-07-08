using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SliderScript : MonoBehaviour
{
    [SerializeField] 
    private Slider slider;
    [SerializeField] 
    private TextMeshProUGUI sliderText;

    // Calling from relevant script in scripts folder
    [SerializeField]
    private Channel2 olfy;

    public string units;
    private int newValue = 0;

    public bool isThisDuration = true;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((value) => {
            // Changes value from float to int
            newValue = Mathf.CeilToInt(value);

            // Changes the text in the UI - Units is what is being measured
            sliderText.text = newValue.ToString("0 " + units);

            // Public button chooses if slider is changing duration or intensity
            if (isThisDuration)
            {
                olfy.duration = newValue;
            }
            else
            {
                olfy.intensity = newValue;
            }
        });
    }
}
