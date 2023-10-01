using System.Collections;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed;
    public float _lifetime;
    public int _damage = 1;
    private float _timeLeft;
    private float _maTime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _timeLeft = _maTime;
    }

    void Update()
    {
        rb.velocity = transform.forward * Speed;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            if (collider != null)
            {
                if (collider.CompareTag("Enemy"))
                {
                    collider.GetComponent<Enemy>().TakeDamageGun(_damage);
                    Destroy(gameObject);
                }
                if (collider.CompareTag("Player"))
                {
                    collider.GetComponent<PlayerControl>().damageHP(_damage);
                    Destroy(gameObject);
                }
                if (collider.CompareTag("Wall"))
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }



}
