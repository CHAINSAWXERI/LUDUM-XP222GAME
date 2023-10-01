using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float HP;

    public void TakeDamageGun(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
