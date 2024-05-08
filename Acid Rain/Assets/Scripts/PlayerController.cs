using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Umbrella umbrella;
    
    private float speed = 5.0f;
    private float nextDamageTick = 0f;
    private float verticalInput;
    private float horizontalInput;
    private int health = 100;

    public bool isWet = true;
    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        umbrella = GameObject.Find("Umbrella").GetComponent<Umbrella>();
    }

    // Update is called once per frame
    void Update()
    {

        verticalInput = Input.GetAxis("Vertical");
        playerRb.transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        if(isWet)
        {
            takeDamage(5, 1.5f);
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void takeDamage(int damage, float damageInterval)
    {
        //uses Time.time to control how often damage is applied, for testing i want it to be every 1.5 seconds
        //updated code to damage umbrella if it is not destroyed
        if((health > 0 && Time.time > nextDamageTick) && umbrella.getDestroyedStatus())
        {
            nextDamageTick = Time.time + damageInterval;
            health -= damage;
            Debug.Log(health);
        }

        if ((health > 0 && Time.time > nextDamageTick) && !umbrella.getDestroyedStatus())
        {
            nextDamageTick = Time.time + damageInterval;
            umbrella.decreaseUHealth(damage);
            Debug.Log(umbrella.getCurrentHealth());
        }
    }

    public void setWetness(bool isWetStatus)
    {
        isWet = isWetStatus;
    }
}
