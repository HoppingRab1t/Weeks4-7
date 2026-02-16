using UnityEngine;

public class ToyMovement: MonoBehaviour
{
    public bool stop = false;
    Vector2 pos;
    public float movement = 1;
    public ToySpawner toySpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        pos.x += movement * Time.deltaTime;


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
