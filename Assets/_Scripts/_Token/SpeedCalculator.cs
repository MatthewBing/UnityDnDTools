using System;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCalculator : MonoBehaviour {
    public InputField speedInput;

    public void OnSpeedEntered()
    {
        speedInput.text = (Convert.ToInt32(speedInput.text) / 5).ToString() + " tiles";
    }
}
