using UnityEngine;

public class Press : MonoBehaviour
{
    bool clicked = false;
     float time=0;
     float time2 = 0;

    public AnimationCurve curve;
    Vector2 start = new(0, 6);

    Vector2 end = new(0, 1.2f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            //Debug.Log("presssssssssss");
            

            transform.position = Vector2.Lerp(start, end, curve.Evaluate(time));

            time += 4 * Time.deltaTime;
            if (time >= 1)
            {
                time = 1;
            }
        }
        else
        {
            transform.position = Vector2.Lerp(end, start, curve.Evaluate(time2));

            time2 += 1 * Time.deltaTime;
            if (time2 >= 1)
            {
                time2 = 1;
            }
        }

    }
    
    public void Pressed()
    {
         start = transform.position;

        clicked = true;
        time2 = 0;
    }
    public void Released()
    {
        start = new(0, 6);

        clicked = false;
        time = 0;
    }
}
