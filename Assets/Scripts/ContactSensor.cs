using UnityEngine;
using UnityEngine.Events;

public class ContactSensor : MonoBehaviour
{
    public SpriteRenderer hazard;
    public bool isInHazard = false;
    public UnityEvent OnEnterHazard;
    public UnityEvent OnExitrHazard;
    public UnityEvent <float> OnRandomNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hazard.bounds.Contains(transform.position))
        {
            if (isInHazard == true)
            {

            }
            else
            {
                isInHazard = true;
                Debug.Log("ENTER");
                OnEnterHazard.Invoke();
            }
        }
        else 
        {
            if (isInHazard)
            {
                isInHazard = false;
                Debug.Log("EXIT");
                OnExitrHazard.Invoke();
                OnRandomNumber.Invoke(Random.Range(0, 10));
            }
            else
            {

            }
        }

    }
    public void showNumber(float number)
    {
        Debug.Log(number);
    }
}
