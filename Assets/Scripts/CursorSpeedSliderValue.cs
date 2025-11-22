using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CursorSpeedSliderValue : MonoBehaviour
{   
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    // Start is called before the first frame update
    void Start()
    {

        float saveCursorSensitivity = PlayerPrefs.GetFloat("CursorSensitivity", 2f);
        _slider.value = saveCursorSensitivity;
        _sliderText.text = saveCursorSensitivity.ToString();
        _slider.onValueChanged.AddListener((v) =>{
        PlayerPrefs.SetFloat("CursorSensitivity", v);
        _sliderText.text = ((int)v).ToString();
        PlayerPrefs.Save();
        });



    }

      public void SetCursorValue(float value)
    {
        _slider.value = value;
        _sliderText.text = value.ToString();
    } 


}
