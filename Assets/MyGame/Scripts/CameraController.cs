using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 2.0f;
    
    private Transform followTarget;
    private  CinemachineVirtualCamera virtualCamera;
    private float mouseX, mouseY;
    // Start is called before the first frame update
    void Start()
    {
        if (virtualCamera == null) {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }
        if (followTarget == null) {
            followTarget = GameObject.FindGameObjectWithTag("Player").transform;
                }
        virtualCamera.Follow = followTarget;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * rotateSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotateSpeed;
        mouseY = Mathf.Clamp(mouseY, -30f, 60f);
        virtualCamera.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }
}
