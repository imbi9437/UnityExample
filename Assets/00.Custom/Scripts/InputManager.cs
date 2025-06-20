using System;
using UnityEngine;

namespace Custom
{
    //todo : Action 캡슐화 하기
    public class InputManager : MonoSingleton<InputManager>
    {
        private Camera _camera;

        public Action<Vector3> OnMove;
        public Action<Vector3> OnFixedMove;
        public Action<Vector3> OnMouseMove;
        public Action<Vector3> OnFixedMouseMove;
        public Action OnJump;
        public Action OnFixedJump;
        public Action OnFire1;
        public Action OnFire1Down;
        public Action OnFire1Up;
        public Action OnFixedFire1;

        public Action OnEscape;

        private Vector3 moveInput;
        private Vector3 mousePos;
        private bool jumpInput;
        private bool fireInput;
        private bool fireDownInput;
        private bool fireUpInput;

        private bool escapeInput;

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
            fireDownInput = Input.GetButtonDown("Fire1");
            fireUpInput = Input.GetButtonUp("Fire1");
            escapeInput = Input.GetKeyDown(KeyCode.Escape);

            if (_camera == false) _camera = Camera.main;
            if (_camera) mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            InvokeUpdateEvent();
        }

        private void FixedUpdate()
        {
            InvokeFixedUpdateEvent();
        }

        private void InvokeUpdateEvent()
        {
            OnMove?.Invoke(moveInput.normalized);
            OnMouseMove?.Invoke(mousePos);

            if (jumpInput) OnJump?.Invoke();
            if (fireInput) OnFire1?.Invoke();
            if (fireDownInput) OnFire1Down?.Invoke();
            if (fireUpInput) OnFire1Up?.Invoke();
            if (escapeInput) OnEscape?.Invoke();
        }

        private void InvokeFixedUpdateEvent()
        {
            OnFixedMove?.Invoke(moveInput.normalized);
            OnFixedMouseMove?.Invoke(mousePos);
            
            if (jumpInput) OnFixedJump?.Invoke();
            if (fireInput) OnFixedFire1?.Invoke();
        }
    }
}