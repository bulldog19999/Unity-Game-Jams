using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    /*
     * Uses a 3d cube, combined with a tree prefab, to function as a shelter
     * When a player enters the general area of a tree or other shelter, the player's isWet variable is set to false
     * This disables damage recieved by the player and their umbrella if it isn't destroyed.
     * Once a player leaves, isWet is set to true, re-enabling damage
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.setWetness(false);  //Stop taking damage
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.setWetness(true); //Start taking damage
        }
    }
}
