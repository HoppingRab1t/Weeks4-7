using UnityEngine;
using UnityEngine.Rendering;

public class Toggle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void wake()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);

        //if (gameObject.activeInHierarchy == false)
        //{
        //    gameObject.SetActive(true);

        //}
        //else if (gameObject.activeInHierarchy == true)
        //{
        //    gameObject.SetActive(false);

        //}
    }
}
