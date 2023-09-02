using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float playerMaxHealth = 3f;
    [SerializeField] float playerCurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void TakeDamage()
    {
        playerCurrentHealth --;
        if (playerCurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        transform.gameObject.SetActive(false);
    }

}
