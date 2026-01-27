using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject spawnedBullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    shoot();
        //}
        if (Keyboard.current.anyKey.wasPressedThisFrame){
            shoot();

        }
    }
    public void shoot()
    {
        spawnedBullet = Instantiate(bulletPrefab,transform.position, transform.rotation);
    }
}
