using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ToyMovement: MonoBehaviour
{
    public bool stop = false;
    Vector2 pos;
    public float movement = 1;
    public ToySpawner toySpawner;

    SpriteRenderer image;

    //old unused code
    public List<Sprite> clothing;

    public bool changed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //changes the rotation of the rock to a random rotation
        transform.eulerAngles = new Vector3(0,0,Random.Range(0,360));


    }

    // Update is called once per frame
    void Update()
    {
        //changes position
        pos = transform.position;
        pos.y = -2;
        pos.x += movement * Time.deltaTime;

        // stops moving if the convayor stops
        if (stop == false)
        {
            transform.position = pos;

        }
        

    }
    public void change(){
        //resets the agnles back to 0
        transform.eulerAngles = Vector3.zero;
       
    }
}
