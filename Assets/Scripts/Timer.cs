using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 0;
    public float max = 10;
    public Slider timerVisuals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerVisuals.maxValue = max;
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;

        if (max <= time)
        {
            time = 0;
        }
       timerVisuals.value = time;   
    }
}
