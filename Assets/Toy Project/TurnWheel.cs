using UnityEngine;
using UnityEngine.Rendering;

public class TurnWheel : MonoBehaviour
{
    bool stop;
    public ToySpawner toySpawner;

    int dir = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        toySpawner = toySpawner.GetComponent<ToySpawner>(); // gets script form toy spawner

        stop = toySpawner.move; // sets the variable for if the track is moving or not

        //change the rotations of the factory wheels and check if the track is moving or not
        if (stop==false)
        {
            dir -= 5;
            transform.eulerAngles = new Vector3(0, 0, dir);
        }

    }
}
