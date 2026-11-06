
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HealthBarUI : MonoBehaviour
{
    public Health playerHealth;
    public Slider healthSlider;

    void Start()
    {
        playerHealth.Changed += UpdateHealthBar;
        UpdateHealthBar(playerHealth.HP, playerHealth.maxHP);
    }

    void UpdateHealthBar(int currentHP, int maxHP)
    {
        healthSlider.maxValue = maxHP;
        healthSlider.value = currentHP;
    }

    void OnDestroy()
    {
        if (playerHealth != null)
            playerHealth.Changed -= UpdateHealthBar;
    }
   
}
