using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class JumpController : MonoBehaviour
{
    public float jumpforce;
    private bool OnGround = true;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("000000000000000");
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }
}