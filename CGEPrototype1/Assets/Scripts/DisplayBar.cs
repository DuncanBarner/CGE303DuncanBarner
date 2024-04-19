using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Import the UnityEngine.UI library 
using UnityEngine.UI;
public class DisplayBar : MonoBehaviour
{
    //Slider component to hold the health bar
    public Slider slider;

    //Gradient for the health bar
    public Gradient gradient;

    //Image for the fill of the health bar
    public Image fill;



    public void SetValue(float value)
    {
        //Taking the value passed in and assign it to the slider object
        slider.value = value;

        //Set the color of the fill of the slider
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    

    public void SetMaxValue(float value)
    {
         //Set the max value of the slider 
        slider.maxValue = value;

        //Set the current value of the slider to the max value
        slider.value = value;

        //Set the color of the fill of the slider
        fill.color = gradient.Evaluate(1f);

    }
    
}
