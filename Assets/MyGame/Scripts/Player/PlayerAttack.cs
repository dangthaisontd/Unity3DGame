using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/PlayerAttack")]
public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackDamage = 5;
    public float attackRate = 1;
    public float nextAttackTime = 0;
    public Transform attactPoint;
    public LayerMask enemyLayer;
    private readonly int[] animId = new int[2];
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        animId[0] = Animator.StringToHash("IsAttackRight");
        animId[1] = Animator.StringToHash("IsAtackLeft");
    }
    void Update()
    {
        if (Time.time > nextAttackTime&&Input.GetButtonDown("Fire1"))
        {
            nextAttackTime = Time.time + attackRate;
            Attack();
        }
    }
    void Attack()
    {
        anim.SetTrigger(animId[Random.Range(0,animId.Length)]);
        Collider[] hitEnemys = Physics.OverlapSphere(attactPoint.position, attackRate, enemyLayer);
        foreach (var enemy in hitEnemys)
        {
            IDamageble obj = enemy.GetComponent<IDamageble>();
            if (obj != null)
            { 
            obj.TakeDamage(5);
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (attactPoint == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attactPoint.position, attackRange);
    }
}
