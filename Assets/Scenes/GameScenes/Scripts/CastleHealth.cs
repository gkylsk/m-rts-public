using Fusion;
using UnityEngine;

public class CastleHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    public float CurrentHealth;

    public HealthBar healthBar;

    public GameManager gameManager;

    private bool hasBeenDestroyed = false; // Tracks if the part has been destroyed

    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

        gameManager = FindObjectOfType<GameManager>();
    }


    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        healthBar.SetHealth(CurrentHealth);

        if (CurrentHealth <= 0 && !hasBeenDestroyed)
        {
            DestroyPart();
            hasBeenDestroyed = true; // Prevents multiple calls to DestroyPart
        }
    }

    void DestroyPart()
    {
        // Implement logic to destroy the part visually
        Destroy(gameObject); // Destroy the part GameObject
        gameManager.PartDestroyed(); // Notify the manager about the destroyed part
    }
}
