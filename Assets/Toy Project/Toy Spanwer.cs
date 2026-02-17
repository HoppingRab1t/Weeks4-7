using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToySpawner : MonoBehaviour
{
    //for instances
    public GameObject toyPrefab; 
    public GameObject target;

    //for spawning with the track
    //public Transform track;

    public List<GameObject> toyCount; // list of instances
    public List<Sprite> clothing; //list for the different sprites.

    //for the spawning of the instances
    float timer = 0;
    float interval = 2;

    public ToyMovement toyMovement; // for instance script and values

    public SpriteRenderer spriteRenderer; // for the press

    public bool move;
    public float TrackMovement = 1;

    float pressure = 0;
    float maxPressure = 10;

    int points = 0;

    bool pressed = false;

    public Slider visuals; // slider for the pressure guage
    public Slider controlLever; // slider for the lever
    public TextMeshProUGUI pointValue; // point value



    Vector2 topRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); //gets the pos of the top right of the screen
        
        //set the min and  max value for the pressure guage UI
        visuals.maxValue = maxPressure;
        visuals.minValue = 0;
        //interval = Random.Range(1,2);
    }

    // Update is called once per frame
    void Update()
    {

        pointValue.text = "QUOTA: " + points.ToString(); // sets point value


        //detects if the switch is toggled or not (it determines whether the convayor moves or not)
        if (controlLever.value == 1)  
        {
            move = true;
        }
        else if (controlLever.value == 0)
        {
            move = false;
        }

        timer += 1 * Time.deltaTime;
        if (timer >= interval && !move) // creates a new prefab instance per interval when the convayor is moving
        {
            //creates new instnace
            toyPrefab = Instantiate(target, transform.position, transform.rotation);
            toyCount.Add(toyPrefab);

            //reset timer
            timer = 0;
        }
        for (int i = 0; i < toyCount.Count; i += 1) // scan through each instance
        {

            toyMovement = toyCount[i].GetComponent<ToyMovement>(); // gets script from the instances
            //move = toyMovement.stop;
            toyMovement.movement = TrackMovement; //sets the toy to a set speed
            toyMovement.stop = move; // sets the toy to either move or not (if the convayor is moving the toy is moving and vice versa)
            

            if (toyMovement.transform.position.x > topRight.x +5) // checks if its off screen
            {
                if (!toyMovement.changed)
                {
                    points -= 200; // decreases points if it leaves the convayor unchanged
                }
                //destroys the toy once it goes off screen
                GameObject toy = toyCount[i];
                toyCount.Remove(toy);
                Destroy(toy);
            }
        }
        //checks if the button is currently being pressed down (detailed desc down below)
        if (pressed)
        {

            //Debug.Log("PRESSSED");


            if (pressure < maxPressure)
            {
                pressure += 5 * Time.deltaTime;
            }
            else if (pressure >= maxPressure) // makes sure it does not go over
            {
                pressure = maxPressure;
            }
        }
        else
        {
            pressure -= ((pressure - 0) / 1.05f) * Time.deltaTime; // slowly resets pressure
            if (pressure <= 0)
            {
                pressure = 0;
            }
        }
        visuals.value = pressure; // sets the pressure gauge UI to the varialbe

    }


    //detects when it is pressed and sets it true if the button is pressed down
    //when the mouse is released it sets it to false.
    // this enables me for the code to keep running as long as the button is pressed down.
    public void ButtonPressed()
    {

        pressed = true;

    }
   
    public void ButtonReleased()
    {
        for (int i = 0; i < toyCount.Count; i += 1)  //scan through the list
        {
            toyMovement = toyCount[i].GetComponent<ToyMovement>(); // gets the instances script

            if (spriteRenderer.bounds.Contains(toyMovement.transform.position)) //check if the instance is in bounds of the press
            {
                if (Vector2.Distance(toyMovement.transform.position, new Vector2(0, -3)) < 2) // checks to see how close to the center it is
                {
                    if (pressure == Mathf.Clamp(pressure, 9, maxPressure)&&!toyMovement.changed) // determines the points based on the right amount of pressure
                    {
                        points += -100;
                    }
                    else if (pressure == Mathf.Clamp(pressure, 7, 9))
                    {
                        points += 300;

                        toyMovement.change();
                        int rand = Random.Range(0, 4);// gets random number
                        toyMovement.GetComponent<SpriteRenderer>().sprite = clothing[rand]; // changes the instance sprite to a random object
                    }
                    else if (pressure == Mathf.Clamp(pressure, 0, 7))
                    {
                        points += 50;
                    }
                    toyMovement.changed = false;
                }
                else
                {
                    points -= 100; // if the 
                }
                //change when the button is pressed instead of the key is pressed.

            }

        }
        pressed = false;

    }
}
