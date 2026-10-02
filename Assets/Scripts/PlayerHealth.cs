using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth, maxHealth;
    //public Slider slider;

   void Start()
   {
    currentHealth = maxHealth;
    //slider.maxValue = maxHealth;
    //slider.value = currentHealth;
   } 

   void Update()
   {

   }
}
