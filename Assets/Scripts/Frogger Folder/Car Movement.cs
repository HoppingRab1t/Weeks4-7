using UnityEngine;

public class CarMovement : MonoBehaviour
{
    int wherey;
    int wherex;

    public GameObject player ;
    public SpriteRenderer spriteRenderer;
    public int speed = 2;
    
    public bool hit = false;

    public Vector2 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        wherey = (Random.Range(2, 0));
        wherex = (Random.Range(-7, 8));
        if (wherey == 1)
        {
            pos.y = 8;
        }
        else if (wherey == 2)
        {
            pos.y = -8;

        }
        pos.x = wherex;
        transform.position = pos;

    }

    // Update is called once per frame
    void Update()
    {
        if (wherey == 1)
        {
            pos.y -= speed * Time.deltaTime;
        }
        else if (wherey == 2)
        {
            pos.y += speed * Time.deltaTime;

        }
        if (Mathf.Abs(pos.y) > 15)
        {
        }
        transform.position = pos;

        if (spriteRenderer.bounds.Contains(player.transform.position))
        {
            hit = true;


        }
    }
}
