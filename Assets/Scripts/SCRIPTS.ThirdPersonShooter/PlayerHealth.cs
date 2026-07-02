using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    
    [SerializeField] private Image healthSlider2;

    [SerializeField] private float healthPercentage;

    [SerializeField] private Player player;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       currentHealth = maxHealth; 
       healthPercentage = currentHealth / maxHealth * 100;
         
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthPercentage = currentHealth / maxHealth * 100;

        healthSlider2.fillAmount = currentHealth/maxHealth;

        if (healthPercentage > 25 && healthPercentage <= 75)
        {
            healthSlider2.color = Color.yellow;
        } else if (healthPercentage <=25)
        {
            healthSlider2.color = Color.red;
        }
        
        if (currentHealth <= 0f)
        {
            player.isAlive = false;
            player.Die();
        }
    }

}
