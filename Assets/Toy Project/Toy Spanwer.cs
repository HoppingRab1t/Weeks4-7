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

    public float timer = 0 ;
    public float interval = 5;
    public ToyMovement toyMovement;

    public SpriteRenderer spriteRenderer;

    public bool move;
    public int TrackMovement = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //interval = Random.Range(1,2);
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= interval)
        {
            //creates new instnace
            toyPrefab = Instantiate(target,transform.position,transform.rotation);
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
                if (Keyboard.current.spaceKey.isPressed)
                {

                }
            }

            if (toyCount[i].transform.position.x > 5)
            {
                //destroys the toy once it goes off screen
                GameObject toy = toyCount[i];
                toyCount.Remove(toy);
                Destroy(toy);
            }
        }
    }
    public void TrackSpeed()
    {

    }
}
