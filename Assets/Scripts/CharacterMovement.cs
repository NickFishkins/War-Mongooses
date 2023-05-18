using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _body2d;
    private float _horizMove;

    public float speed;
    public float walkSpeed = 4f;
    public float sprintSpeed = 7f;

    public float jumpForce = 1f;

    void Start()
    {
        _body2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizMove = speed * Input.GetAxis("Horizontal");

        // Movement left and right
        transform.Translate(new Vector2(_horizMove, 0) * Time.deltaTime);

        // Running
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _body2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }else
        {
            speed = walkSpeed;
        }
    }
}
