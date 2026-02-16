using UnityEngine;

public class TrackMovement : MonoBehaviour
{
    public bool stop;
    public int speed;
    Vector2 pos;

    Vector2 bottomLeft;
    Vector2 topRight;

    public ToySpawner toySpawner;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }

    // Update is called once per frame
    void Update()
    {            
        
        toySpawner = GetComponent<ToySpawner>();

        pos = transform.position;
        pos.x += toySpawner.TrackMovement * Time.deltaTime;
        //stop = toySpawner.move;


        if (pos.x >= topRight.x)
        {
            pos.x = -13;
        }

        if (stop == false)
        {
            transform.position = pos;
        }
    }
}
