using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageAmount;
    public GameObject explosionEffect;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealDamage(PlayerHealth playerHealth)
    {
        playerHealth.currentHealth -= damageAmount;
        //slider.value = currentHealth;

        if (playerHealth.currentHealth <= 0)
        {
            playerHealth.gameObject.SetActive(false);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            DealDamage(playerHealth);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    } 
}
