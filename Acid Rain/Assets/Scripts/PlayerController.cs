using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Umbrella umbrella;
    private GameManager gameManager;
    
    private float speed = 5.0f;
    private float nextDamageTick = 0f;
    private float verticalInput;
    private float horizontalInput;
    private int health = 50;
    private bool isJumping = false;
    private bool isDead = false;
    private Vector3 jumpForce = new Vector3(0, 5.5f, 0);

    public bool isWet = true;
    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        umbrella = GameObject.Find("Umbrella").GetComponent<Umbrella>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!gameManager.getGameOverStatus())
        {
            //Set horizontal and vertical inputs to respective axis
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
            playerRb.transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
            playerRb.transform.Translate(Vector3.right * (speed * 0.8f) * horizontalInput * Time.deltaTime);

            if(isWet)
            {
                takeDamage(5, 1.5f);
            }

            if(health <= 0)
            {
                isDead = true;
                gameObject.SetActive(false);
                gameManager.setGameOverStatus(true);
            }

            if((Input.GetKeyDown(KeyCode.Space)) && !isJumping)
            {
                jump();
                isJumping = true;
            }
        }
        
    }

    public void takeDamage(int damage, float damageInterval)
    {
        //uses Time.time to control how often damage is applied, for testing i want it to be every 1.5 seconds
        //updated code to damage umbrella if it is not destroyed
        if((health > 0 && Time.time > nextDamageTick) && umbrella.getDestroyedStatus())
        {
            nextDamageTick = Time.time + (damageInterval * 0.5f);
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

    public bool getIsDead()
    {
        return isDead;
    }

    private void jump()
    {
        playerRb.AddForce(jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Goal"))
        {
            gameManager.setGameOverStatus(true);
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
