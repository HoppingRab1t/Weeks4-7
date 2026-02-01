using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public float movement = 10f;
    public SpriteRenderer body;
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
        Vector2 newPos = transform.position;
        newPos.x += (movement * Time.deltaTime);
        //transform.position = newPos;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0 || screenPos.x > Screen.width)
        {
            movement = movement * -1;
            //movement += Random.Range(10,-10);
            // Random.InsideUnitCircle * 5     // the range for unit circle is in between 1 and -1, to increase the size you simply add a multiplication on the side
        }

        if (screenPos.x < 0)
        {
            newPos.x = bottomLeft.x;
        }
        if (screenPos.x > Screen.width)
        {
            newPos.x = topRight.x;
        }
        transform.position = newPos;
    }
    }
// the postion and stuff is based on the pivot of the group, not the center