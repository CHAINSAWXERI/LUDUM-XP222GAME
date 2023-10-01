using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private CharacterController controller;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible= false;
    }

    private void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        Vector3 moveDir = transform.forward * verInput + transform.right * horInput;

        moveDir.y -= 9.81f * Time.deltaTime;

        controller.Move(moveDir * speed * Time.deltaTime);
    }
}
