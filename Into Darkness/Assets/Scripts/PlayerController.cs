using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 6f;
    Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            Vector2 momentum = rbody.velocity;
        if (Input.GetKey("a")) {
                momentum.x = -speed;
                rbody.velocity = momentum;
        } else if (Input.GetKey("d")) {
                momentum.x = speed;
                rbody.velocity = momentum;
        }

        if (Input.GetKeyDown("e")) {
                GameObject inv = gameObject.transform.Find("PlayerInventory").gameObject;
                inv.SetActive(!inv.activeSelf);
        }
        
    }
}
