using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToySpawner : MonoBehaviour
{

    public GameObject toyPrefab;
    public GameObject target;

    //for spawning with the track
    //public Transform track;

    public List<GameObject> toyCount;

    public float timer = 0;
    public float interval = 5;
    public ToyMovement toyMovement;

    public SpriteRenderer spriteRenderer;

    public bool move;
    public float TrackMovement = 1;

    float pressure = 0;
    float maxPressure = 10;

    int points = 0;

    bool pressed = false;

    Vector2 topRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //interval = Random.Range(1,2);
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= interval)
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
            move = toyMovement.stop;
            toyMovement.movement = TrackMovement;
            if (spriteRenderer.bounds.Contains(toyCount[i].transform.position))
            {
                //change when the button is pressed instead of the key is pressed.

            }

            if (toyCount[i].transform.position.x > 5)
            {
                //destroys the toy once it goes off screen
                GameObject toy = toyCount[i];
                toyCount.Remove(toy);
                Destroy(toy);
            }
        }
        if (pressed)
        {
            Debug.Log("PRESSSED");


            if (pressure < maxPressure)
            {
                pressure += 2 * Time.deltaTime;
            }
            else if (pressure >= maxPressure)
            {
                pressure = maxPressure;
            }
        }
    }
    public void ButtonPressed()
    {

        pressed = true;

    }
    public void ButtonReleased()
    {
        pressed = false;
        if (pressure == Mathf.Clamp(pressure, 8, maxPressure))
        {
            points += -1;
        }
        else if (pressure == Mathf.Clamp(pressure, 6, 8))
        {
            points += 3;
        }
        else if (pressure == Mathf.Clamp(pressure, 0, 6))
        {
            points += 1;
        }
        pressure = 0;
    }
}
