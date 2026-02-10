using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject prefab;
    public GameObject target;

    public List<GameObject> car;

    public CarMovement carScript;
    public FroggerMovement frog;

    public float time = 0;
    float delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        delay = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
        if (time >= delay)
        {
            prefab = Instantiate(target,transform.position,transform.rotation);
            car.Add(prefab);

            delay = Random.Range(1, 5);
            time = 0;


        }
        for (int i = car.Count; 0 < i; i -= 1)
        {
            carScript = prefab.GetComponent<CarMovement>();
            if (carScript.hit == true)
            {
                carScript.hit = false;
                frog.death();
            }
            if (Mathf.Abs(carScript.pos.y) > 15)
            {
                car.Remove(prefab);
                Destroy(prefab,i);

            }



        }
        //spawn a car 
        //destroys the car when they reach to a certain point 
    }
}
