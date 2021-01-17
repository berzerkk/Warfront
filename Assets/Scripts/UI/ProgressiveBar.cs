using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressiveBar : MonoBehaviour {
    private Image _bar;
    void Start () {
        _bar = GetComponent<Image> ();
    }
    public void SetBarValue (float value) {
        _bar.fillAmount = value;
    }
    public  void SetBarColor (Color healthColor) {
        _bar.color = healthColor;
    }
    public void Active(bool state) {
        GetComponent<Image>().enabled = state;
    }
}