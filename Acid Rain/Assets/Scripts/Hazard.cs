using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private PlayerController pc;
    
    private float damageInterval = 1.5f;
    private int damage = 5;
    // Start is called before the first frame update
    void Awake()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) {
            pc.takeDamage(damage, damageInterval);
        }
    }
}
