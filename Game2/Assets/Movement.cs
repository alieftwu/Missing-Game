using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed; 
    private Rigidbody2D rb;
    private Vector2 movInput;
    public Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetFloat("Horizontal", movInput.x);
        animator.SetFloat("Vertical", movInput.y);
        animator.SetFloat("Speed", movInput.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rb.velocity = movInput * speed;
        
    }

    private void OnMove(InputValue inputValue)
    {
        movInput = inputValue.Get<Vector2>();
    }
}
