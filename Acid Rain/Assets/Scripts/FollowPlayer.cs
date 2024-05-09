using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private PlayerController pc;
    private Vector3 cameraOffset = new Vector3(0,0.5f,-2);
    // Start is called before the first frame update
    void Awake()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = pc.transform.position + cameraOffset;
    }
}
