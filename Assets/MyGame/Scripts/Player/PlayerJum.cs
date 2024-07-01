using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[AddComponentMenu("DangSon/PlayerJum")]
public class PlayerJum : MonoBehaviour
{
    public float jumfor = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody rb;
    private Animator anim;
    private int isJumId;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isJumId = Animator.StringToHash("IsJum");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGroundCheck() && Input.GetKeyDown(KeyCode.Space))
        {
            Jum();
        }
    }
    void Jum()
    {
        anim.SetTrigger(isJumId);
        rb.velocity = new Vector3(rb.velocity.x,jumfor,rb.velocity.z);
    }
    bool IsGroundCheck()
    {
        bool isground = Physics.CheckSphere(groundCheck.position, groundCheckRadius,groundLayer);
        return isground;
    
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }

}
