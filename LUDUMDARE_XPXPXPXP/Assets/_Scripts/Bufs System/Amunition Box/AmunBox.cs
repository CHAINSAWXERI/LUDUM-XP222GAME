using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmunBox : MonoBehaviour
{
    public Gun _gun;
    public int AmunInBox;

    void Start()
    {
        _gun = FindObjectOfType<Gun>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gun.TakeBoxAm(AmunInBox);
            Destroy(gameObject);
        }
    }
}
