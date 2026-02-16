using UnityEngine;

public class ToyMovement: MonoBehaviour
{
    public bool stop = false;
    Vector2 pos;
    public int movement = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        pos.x += movement;

        //if (pos.x <= 0)
        //{
        //    stop = false;
        //}
        if (stop == false)
        {
            transform.position = pos;

        }
        

    }
}
