using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsBox : MonoBehaviour
{
    public PlayerControl _plr;
    public int PillsInox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _plr.addHP(PillsInox);
            Destroy(gameObject);
        }
    }
}
