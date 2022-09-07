using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] Gun _gun;
    private Rigidbody _rb;
    private Vector3 _moveInput;
    private Vector3 _moveVelocity;
    private Camera _mainCamera;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        _moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        _moveVelocity = _moveInput * _moveSpeed;

        Ray cameraRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3 (pointToLook.x,transform.position.y,pointToLook.z));
        }

        if(Input.GetMouseButtonDown(0))
        {
            _gun.isFiring = true;
        }

        if(Input.GetMouseButtonUp(0))
        {
            _gun.isFiring = false;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveVelocity;
    }
}
