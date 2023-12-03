using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    private Rigidbody2D _rb;
    private Animator _anim;
    bool grounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move;

        if (Input.GetKey(KeyCode.W) && grounded) {
            _rb.AddForce(new Vector2(_rb.velocity.x, jump * 10));
        }
        if (Input.GetKey(KeyCode.A)) {
            move = new Vector2(speed * Time.deltaTime, 0);
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(-1, 1, 1);
            _anim.SetBool("running", true);
            if ((transform.position + move).x > -9)
                transform.position -= move;
        } else if (Input.GetKey(KeyCode.D)) {
            move = new Vector2(speed * Time.deltaTime, 0);
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(1, 1, 1);
            _anim.SetBool("running", true);
            if ((transform.position + move).x < 9)
                transform.position += move;
        } else {
            _anim.SetBool("running", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            grounded = true;
        if (other.gameObject.CompareTag("Enemy"))
            _anim.SetBool("Hurt", true);

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            grounded = false;
        if (other.gameObject.CompareTag("Enemy"))
            _anim.SetBool("Hurt", false);
    }
}