using UnityEngine;

public class TrackMovement : MonoBehaviour
{
    public bool stop;
    public float speed;
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
        
        toySpawner = toySpawner.GetComponent<ToySpawner>(); // gets script form toy spawner

        speed = toySpawner.TrackMovement;
        stop = toySpawner.move; // sets the variable for if the track is moving or not
        pos = transform.position;
        pos.x += speed * Time.deltaTime;
        //stop = toySpawner.move;


        if (pos.x >= topRight.x) // resets position if it gets to the edge of the screen
        {
            pos.x = -13;
        }

        if (stop == false) // moves when the track is moving
        {
            transform.position = pos;
        }
    }
}
