using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // public Sprite Up;
    // public Sprite Down;
    // public Sprite Right;
    // public Sprite Left;
    public float speed;
    public float jump;
    private Rigidbody2D _rb;
    bool grounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move;

        if (Input.GetKey(KeyCode.W) && grounded)
        {
            // GetComponent<SpriteRenderer>().sprite = Up;
            _rb.AddForce(new Vector2(_rb.velocity.x, jump * 10));
        }
        if (Input.GetKey(KeyCode.A))
        {
            // GetComponent<SpriteRenderer>().sprite = Left;
            move = new Vector2(speed * Time.deltaTime, 0);
            if ((transform.position + move).x > -9)
                transform.position -= move;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // GetComponent<SpriteRenderer>().sprite = Right;
            move = new Vector2(speed * Time.deltaTime, 0);
            if ((transform.position + move).x < 9)
                transform.position += move;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            grounded = false;
    }
}