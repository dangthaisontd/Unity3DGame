using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/PlayerController")]
public class PlayerController : MonoBehaviour
{
    #region public variable
    public float speed = 5f;
    public float turnSpeed = 200f;
    #endregion
    #region private variable
    private Animator anim;
    private Rigidbody rb;
    private int verticalId;
    private int horizontalId;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        verticalId = Animator.StringToHash("Vertical");
        horizontalId = Animator.StringToHash("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        Vector3 movement = transform.forward * move*speed*Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, turn * turnSpeed * Time.deltaTime, 0f);
        rb.MovePosition(rb.position + movement);
        rb.MoveRotation(rb.rotation*rotation);
        anim.SetFloat(verticalId,move);
        anim.SetFloat(horizontalId,turn);
    }
}
