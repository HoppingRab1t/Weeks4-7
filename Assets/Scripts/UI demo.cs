using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIdemo : MonoBehaviour
{
    private SpriteRenderer sr;
    float scalesss = 0 ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            changeColour();
        }
        
    }

    public void changeColour()
    {
        sr.color = Random.ColorHSV();
    }
    public void changeScale(float scale)
    {
        scalesss += scale;
        transform.localScale = Vector3.one * scalesss;
    }
}
