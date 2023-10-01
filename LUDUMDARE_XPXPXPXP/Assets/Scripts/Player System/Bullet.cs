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

    private void OnCollisionEnter(Collision collision)
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            if (collision != null)
            {
                Destroy(gameObject);
                if (collision.collider.CompareTag("Enemy"))
                {
                    collision.collider.GetComponent<Enemy>().TakeDamageGun(_damage);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
