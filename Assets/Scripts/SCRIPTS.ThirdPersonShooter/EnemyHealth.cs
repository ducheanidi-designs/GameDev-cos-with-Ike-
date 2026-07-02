using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private GameObject explode;
    
    [SerializeField] private Image healthBar;
    [SerializeField] private float healthPercentage;

    [SerializeField] private Enemy enemy;
    
    private void Start()
    {
        currentHealth = maxHealth;
        healthPercentage = (currentHealth / maxHealth) * 100;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthPercentage = (currentHealth / maxHealth) * 100;

        healthBar.fillAmount = currentHealth/maxHealth;

        if (healthPercentage > 25 && healthPercentage <= 75)
        {
            healthBar.color = Color.yellow;
        } else if (healthPercentage <=25)
        {
            healthBar.color = Color.red;
        }
        
        
        if (currentHealth <= 0)
        {
            enemy.isAlive = false;
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        enemy.Die();
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
