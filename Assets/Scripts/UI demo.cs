using JetBrains.Annotations;
using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIdemo : MonoBehaviour
{
    private SpriteRenderer sr;
    float scalesss = 0 ;
    public Image duckieImage;//image of the duck on ui
    public int howManyClicks = 0;
    public TextMeshProUGUI score;
    public Slider slider;
    public TextMeshProUGUI sliderDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        slider.wholeNumbers = true;
    }

    // Update is called once per frame
    void Update()
    {
        sliderDisplay.text = slider.value.ToString();
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            changeColour();
        }
        
    }

    public void changeColour()
    {
        Color col = Random.ColorHSV();
        sr.color = col;
        duckieImage.color = col;
    }
    public void changeScale(float scale)
    {
        scalesss = scale;
        transform.localScale = Vector3.one * scalesss;
    }
    public void AddToTheNumber()
    {
        //chanign the text of the UI
        howManyClicks += 1;
        score.text = "CLICKY STUFFY"+ howManyClicks.ToString(); // convert anyhting into  a string
    }
}
