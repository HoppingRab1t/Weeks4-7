using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToySpawner : MonoBehaviour
{

    public GameObject toyPrefab;
    public GameObject target;

    //for spawning with the track
    //public Transform track;

    public List<GameObject> toyCount;
    public List<Sprite> clothing;


    float timer = 0;
    float interval = 2;

    public ToyMovement toyMovement;

    public SpriteRenderer spriteRenderer;

    public bool move;
    public float TrackMovement = 1;

    float pressure = 0;
    float maxPressure = 10;

    int points = 0;

    bool pressed = false;

    public Slider visuals;
    public Slider controlLever;
    public TextMeshProUGUI pointValue;



    Vector2 topRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        visuals.maxValue = maxPressure;
        visuals.minValue = 0;
        //interval = Random.Range(1,2);
    }

    // Update is called once per frame
    void Update()
    {

        pointValue.text = "QUOTA: " + points.ToString();

        if (controlLever.value == 1)
        {
            move = true;
        }
        else if (controlLever.value == 0)
        {
            move = false;
        }

        timer += 1 * Time.deltaTime;
        if (timer >= interval && !move)
        {
            //creates new instnace
            toyPrefab = Instantiate(target, transform.position, transform.rotation);
            toyCount.Add(toyPrefab);

            //reset timer
            timer = 0;
        }
        for (int i = 0; i < toyCount.Count; i += 1)
        {

            toyMovement = toyCount[i].GetComponent<ToyMovement>();
            //move = toyMovement.stop;
            toyMovement.movement = TrackMovement;
            toyMovement.stop = move;
            if (spriteRenderer.bounds.Contains(toyMovement.transform.position))
            {
                //change when the button is pressed instead of the key is pressed.

            }

            if (toyMovement.transform.position.x > topRight.x +5)
            {
                //destroys the toy once it goes off screen
                GameObject toy = toyCount[i];
                toyCount.Remove(toy);
                Destroy(toy);
            }
        }
        if (pressed)
        {

            //Debug.Log("PRESSSED");


            if (pressure < maxPressure)
            {
                pressure += 5 * Time.deltaTime;
            }
            else if (pressure >= maxPressure)
            {
                pressure = maxPressure;
            }
        }
        else
        {
            pressure -= ((pressure - 0) / 1.05f) * Time.deltaTime;
            if (pressure <= 0)
            {
                pressure = 0;
            }
        }
        visuals.value = pressure;

    }
    public void ButtonPressed()
    {

        pressed = true;

    }
    public void pressureReset()
    {
        //currently unused 
    }
    public void ButtonReleased()
    {
        for (int i = 0; i < toyCount.Count; i += 1)
        {
            toyMovement = toyCount[i].GetComponent<ToyMovement>();

            if (spriteRenderer.bounds.Contains(toyMovement.transform.position))
            {
                if (Vector2.Distance(toyMovement.transform.position, new Vector2(0, -3)) < 2)
                {
                    if (pressure == Mathf.Clamp(pressure, 9, maxPressure))
                    {
                        points += -100;
                    }
                    else if (pressure == Mathf.Clamp(pressure, 7, 9))
                    {
                        points += 300;
                        toyMovement.change();
                        int rand = Random.Range(0, 4);
                        toyMovement.GetComponent<SpriteRenderer>().sprite = clothing[rand];
                    }
                    else if (pressure == Mathf.Clamp(pressure, 0, 7))
                    {
                        points += 50;
                    }
                }
                else
                {
                    points -= 100;
                }
                //change when the button is pressed instead of the key is pressed.

            }

        }
        pressed = false;

    }
}
