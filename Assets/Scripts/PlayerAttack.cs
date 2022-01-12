using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            StartAttackAnimation();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void StartAttackAnimation()
    {
        cooldownTimer = 0;

        anim.SetTrigger("attack");
    }

    private void Attack()
    {
        int fireball = FindFireball();

        // pool fireballs
        fireballs[fireball].transform.position = firePoint.position;
        fireballs[fireball].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for(int i = 0; i < fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }

        return 0;
    }
}
