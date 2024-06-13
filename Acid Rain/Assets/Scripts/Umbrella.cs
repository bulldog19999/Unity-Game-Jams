using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    private static int baseHealth = 20;
    private int currentHealth = baseHealth;
    private bool isDestroyed = false;

    // Update is called once per frame
    void Update()
    {
        //Deactivate the umbrella object when it's health reaches 0
        if (currentHealth <= 0) 
        {
            Debug.Log("Umbrella Destroyed");
            gameObject.SetActive(false);
            isDestroyed = true;
        }
    }

    //So far not used, intended to have pickups that restores umbrella's health and reactivates it.
    public void increaseUHealth(int value)
    {
        currentHealth += value;
    }

    public void decreaseUHealth(int value)
    {
        currentHealth -= value;
    }
    //also unused code, intended as a way to reset umbrella for level switches and testing
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
