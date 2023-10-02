using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject Portal;
    public int DeatheScene;
    public float speed;
    private CharacterController controller;
    public int HP;
    public int SchetchikEnemy;
    //private int x;


    private void Start()
    {
        Portal.SetActive(false);
        text.text = "Lives: " + HP;
        controller = GetComponent<CharacterController>();
        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible= false;
    }

    private void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        Vector3 moveDir = transform.forward * verInput + transform.right * horInput;

        //moveDir.y -= 9.81f * Time.deltaTime;

        controller.Move(moveDir * speed * Time.deltaTime);

        if (HP <= 0)
        {
            SceneManager.LoadScene(DeatheScene);
        }
        /*
        if (SchetchikEnemy <= x)
        {
            Portal.SetActive(true);
        }
        */

    }
/*
    public void EnemyKills()
    {
        x = x + 1;
    }
*/
    public void damageHP(int damage)
    {
        HP -= damage;
        text.text = "Lives: " + HP;
    }

    public void addHP(int heal)
    {
        HP += heal;
        text.text = "Lives: " + HP;
    }
}
