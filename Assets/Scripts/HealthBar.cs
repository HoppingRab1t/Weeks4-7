using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
        public SpriteRenderer player;
    public int health = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.maxValue = health;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (player.bounds.Contains(mousePos) && Mouse.current.leftButton.wasPressedThisFrame)
        {
            health -= 1;
            if (health == 0)
            {
                gameObject.SetActive(false);
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
