using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class SliderValue : MonoBehaviour
{   
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    void Start()
  {

    float saveSpeed = PlayerPrefs.GetFloat("PlayerSpeed", 6f);

    _slider.value = saveSpeed;

    _sliderText.text = saveSpeed.ToString();

    _slider.onValueChanged.AddListener((v) =>{
      PlayerPrefs.SetFloat("PlayerSpeed", v);
      _sliderText.text = v.ToString();
      PlayerPrefs.Save();
    });
  }

  public void SetSpeedValue(float value)
    {
        _slider.value = value;
        _sliderText.text = value.ToString();
    } 
}
