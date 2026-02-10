using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class FroggerMovement : MonoBehaviour
{
    Vector2 move;

    int points = 0;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = transform.position;

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            move.x += 1 ;
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            move.x -= 1;
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            move.y += 1 ;
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            move.y -= 1 ;
        }
        transform.position = move;


        if (transform.position.x == 8)
        {
            points += 1;
            transform.position = new Vector2(-9, 0);//zero ;
        }


        // add an invisable bpunderiy that prevents the player from moving off the border or screen
        // if the player moves to the far end of the screen they will increase the points and ui by 1
        //if the player gets hit by a car they will go back
        //make an interval for the player when moving
    }
    public void death()
    {
        transform.position = new Vector2(-9, 0);//zero ;


    }
}
