using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSlider : MonoBehaviour
{
    // Start is called before the first frame update
  public void Reset()
  {
    PlayerPrefs.SetFloat("PlayerSpeed", 10f);
    PlayerPrefs.SetFloat("CursorSensitivity", 2f);
    PlayerPrefs.Save();

     // Update speed slider UI
    SliderValue speedSlider = FindObjectOfType<SliderValue>();
    if (speedSlider != null)
        speedSlider.SetSpeedValue(10f);

    // Update cursor slider UI
    CursorSpeedSliderValue cursorSlider = FindObjectOfType<CursorSpeedSliderValue>();
    if (cursorSlider != null)
        cursorSlider.SetCursorValue(2f);

  }
}
