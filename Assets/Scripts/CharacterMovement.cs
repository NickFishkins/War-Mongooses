using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _body2d;
    private float _horizMove;
    public bool isGrounded;

    public float speed;
    public float walkSpeed = 4f;
    public float sprintSpeed = 7f;

    public float jumpForce = 1f;
    public float gravity = 5f;

    void Start()
    {
        isGrounded = true;
        _body2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizMove = speed * Input.GetAxis("Horizontal");

        _body2d.gravityScale = (isGrounded && Mathf.Approximately(_horizMove, 0)) ? 0 : gravity;

        // Movement left and right
        transform.Translate(new Vector2(_horizMove, 0) * Time.deltaTime);

        // Running
        if (Input.GetKey(KeyCode.Space) && isGrounded || Input.GetKey(KeyCode.W) && isGrounded)
        {
            _body2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
