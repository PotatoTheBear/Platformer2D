using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealth = 6;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}
