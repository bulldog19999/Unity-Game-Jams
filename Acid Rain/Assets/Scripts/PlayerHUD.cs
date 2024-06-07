using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHUD : MonoBehaviour
{
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI umbrellaStatusText;
    
    private Umbrella umbrella;
    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        umbrella = GameObject.Find("Umbrella").GetComponent<Umbrella>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Health: " + pc.GetHealth();
        
        if(umbrella.getDestroyedStatus())
        {
            umbrellaStatusText.text = "Umbrella DESTROYED!";
        }
        else
        {
            umbrellaStatusText.text = "Umbrella Health: " + umbrella.getCurrentHealth();
        }
    }
}
