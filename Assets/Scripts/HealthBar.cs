using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
        public SpriteRenderer player;
    public int health = 5;
    public AudioSource audioSource;
    public AudioClip sqeak;
    public AudioClip death;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.maxValue = health;

    }

    // Update is called once per frame
    void Update()
    {
        //audio souce stops and restarts
        //play one shot is adding onto the already played sound
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (player.bounds.Contains(mousePos) && Mouse.current.leftButton.wasPressedThisFrame)
        {
            health -= 1;
            ;
            if (health == 0)
            {
                audioSource.clip = death;
                audioSource.Play();
                //audioSource.PlayOneShot(death);
                gameObject.SetActive(false);
            }
            else
            {
                audioSource.clip = sqeak;
                audioSource.Play();
            }
        }
        healthBar.value = health;
    }

    public void heal()
    {
        gameObject.SetActive(true);
        health = (int)healthBar.maxValue;
        healthBar.value = health;

    }
}
