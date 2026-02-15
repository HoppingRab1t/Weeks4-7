using UnityEngine;

public class TrackMovement : MonoBehaviour
{
    public bool track_move = true;
    public int speed;
    Vector2 pos;

    Vector2 bottomLeft;
    Vector2 topRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        pos.x += speed * Time.deltaTime;

        if (pos.x >= topRight.x)
        {
            pos.x = -13;
        }

        if (track_move == true)
        {
            transform.position = pos;
        }
        
    }
}
