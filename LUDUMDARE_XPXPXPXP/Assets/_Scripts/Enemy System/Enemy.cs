using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float triggerZoneRadius;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float shotDelayTime;

    [field: SerializeField] public float MaxHP { get; private set; }

    private float curShotDelayTime;
    private float curHP;
    private bool isPlayerEnteredTriggerZone = false;
    private bool isDead = false;

    private Transform player;
    private Animator anim;


    private void Start()
    {
        curHP = MaxHP;

        anim = GetComponent<Animator>();

        player = GameObject
            .FindGameObjectWithTag("Player")
            .GetComponent<Transform>();
    }

    public void TakeDamageGun(float damage)
    {
        curHP -= damage;
        if (!isDead) anim.Play(HashedAnimationsData.TakeDamage);
        if (curHP <= 0)
        {
            Death();
        }
    }

    private void Update()
    {
        bool result = IsPlayerEnteredTriggerZone();
        if(result && !isDead)
        {
            LookAtPlayer();
            ShootPlayer();
        }
    }

    private void ShootPlayer()
    {
        if (curShotDelayTime <= 0)
        {
            anim.Play(HashedAnimationsData.Shoot);
            Rigidbody spawnedBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            curShotDelayTime = shotDelayTime;
        }
        else
        {
            curShotDelayTime -= Time.deltaTime;
        }
    }

    private void LookAtPlayer()
    {
        Vector3 relative = transform.InverseTransformPoint(player.position);
        float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
        transform.Rotate(0, angle * rotationSpeed * Time.deltaTime, 0);
    }

    private bool IsPlayerEnteredTriggerZone()
    {
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, triggerZoneRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject == player.gameObject)
            {
                isPlayerEnteredTriggerZone = true;
            }
        }
        return isPlayerEnteredTriggerZone;
    }

    private void Death()
    {
        anim.Play(HashedAnimationsData.Death);
        isDead = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerZoneRadius);
    }
}
