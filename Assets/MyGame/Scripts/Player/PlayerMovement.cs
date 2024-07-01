using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/PlayerMovement")]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumHeight = 2f;
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundLayer;
    private Vector3 velocity;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {

        MovePlayer();
        JumPlayer();
    }
    private bool CheckGround()
    {   
       bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
       return isGrounded;
    }
    private void MovePlayer()
    {
        if (CheckGround() && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }
    private void JumPlayer()
    {
            if (Input.GetButtonDown("Jump") && CheckGround())
            {
                velocity.y = Mathf.Sqrt(jumHeight * -2f * gravity);
            }
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
     }
}
