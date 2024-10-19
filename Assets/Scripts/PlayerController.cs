using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        CharacterController controller;
        [SerializeField] float movX;

        float gravityScale = -9.8f;
        [Range(0, 5)]
        public float speed;
        [Range(1, 5)]
        public int jumpForce;
        Vector3 movement;
        [SerializeField] Vector2 gravity;

        [Header("Rotation Variables")]

        public float xRotation; // Para almacenar la rotación en el eje X
        public float yRotation; // Para almacenar la rotación en el eje Y


        void Start()
        {
            controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked; // Desaparece el cursor de la pantalla para asegurar un uso más cómodo
        }
        void Update()
        {
            CallInputs();
            MovePlayer();

            if (Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                JumpPlayer();
            }

            if (!controller.isGrounded)
            {
                ApplyGravity();
            }
            else
            {
                gravity.y = -2;
            }
        }
        void CallInputs()
        {
            movX = Input.GetAxis("Horizontal");
        }

        void MovePlayer()
        {
            movement = transform.right * movX;
            controller.SimpleMove(movement * speed);
        }
        void ApplyGravity()
        {
            gravity.y += gravityScale * Time.deltaTime;
            controller.Move(gravity * Time.deltaTime);
        }

        void JumpPlayer()
        {
            gravity.y = Mathf.Sqrt(jumpForce * -2 * gravityScale);
            controller.Move(gravity * Time.deltaTime);
        }

    }




