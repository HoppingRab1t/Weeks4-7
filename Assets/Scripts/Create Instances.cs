using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class CreateInstances : MonoBehaviour
{
    public GameObject instance;
    public GameObject prefab;

    public AudioSource audioSource;

    public List<GameObject> howMany;
    public AudioClip sqeak;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    /// <summary>
    /// figure out how to remove instances, when their HP goes down
    /// either by getting their data and evalutate it here
    /// or something else IDK
    /// get conponement script 
    /// heathbar hp = howmany things [i] . get compenemtn <healthbar>();
    /// </summary>
   
    void Start()
    {
        for (int i = 0;i <= 4; i += 1)
        {
            instance = Instantiate(prefab,Random.insideUnitCircle*5,transform.rotation);
            howMany.Add(instance);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
        if (howMany.Count <= 1)
        {
            audioSource.clip = sqeak;
            audioSource.Play();

            Debug.Log("EVRYONE IS DEAD");
        }
    }
    public void Spawn(){
        instance = Instantiate(prefab, Random.insideUnitCircle * 5, transform.rotation);
        howMany.Add(instance);
    }
}
