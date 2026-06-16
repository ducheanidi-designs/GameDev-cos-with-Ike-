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
    
    private void Start()
    {
        currentHealth = maxHealth;
        healthPercentage = (currentHealth / maxHealth) * 100;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

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
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        Instantiate (explode, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }
}
