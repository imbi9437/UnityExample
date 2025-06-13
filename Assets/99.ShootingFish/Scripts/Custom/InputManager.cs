using System;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    private Camera _camera;
    
    public Action<Vector3> OnMove;
    public Action<Vector3> OnMouseMove;
    public Action OnJump;
    public Action OnFire1;
    
    private Vector3 moveInput;
    private Vector3 mousePos;
    private bool jumpInput;
    private bool fireInput;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        jumpInput = Input.GetButton("Jump");
        fireInput = Input.GetButton("Fire1");

        
        if (_camera == false) _camera = Camera.main;
        if (_camera) mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        InvokeEvent();
    }

    private void InvokeEvent()
    {
        OnMove?.Invoke(moveInput.normalized);
        OnMouseMove?.Invoke(mousePos);
        
        OnJump?.Invoke();
        OnFire1?.Invoke();
    }
}
