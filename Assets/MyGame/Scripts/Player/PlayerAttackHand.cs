using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/PlayerAttackHand")]
public class PlayerAttackHand : MonoBehaviour
{
    public HandleAttack handleLeft;
    public HandleAttack handleRight;
    public float attackRate = 1;
    public float nextAttackTime = 0;
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
        if (Time.time > nextAttackTime && Input.GetButtonDown("Fire1"))
        {
            nextAttackTime = Time.time + attackRate;
            Attack();
        }
    }
    void Attack()
    {
        int randVariable = Random.Range(0, animId.Length);
        anim.SetTrigger(animId[randVariable]);
        if(randVariable==0)
        {
            handleLeft.SetHandle();
        }
        if (randVariable == 1)
        {
            handleRight.SetHandle();  
        }  
    }
}
