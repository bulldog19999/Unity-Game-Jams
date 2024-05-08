using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    private static int baseHealth = 20;
    private int currentHealth = baseHealth;
    public bool isDestroyed = false;

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) 
        {
            Debug.Log("Umbrella Destroyed");
            gameObject.SetActive(false);
            isDestroyed = true;
        }
    }

    public void increaseUHealth(int value)
    {
        currentHealth += value;
    }

    public void decreaseUHealth(int value)
    {
        currentHealth -= value;
    }

    public void resetUmbrella()
    {
        isDestroyed = false;
        currentHealth = baseHealth;
        gameObject.SetActive(true);
    }

    public bool getDestroyedStatus()
    {
        return isDestroyed;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }
}
