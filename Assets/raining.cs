using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raining : MonoBehaviour
{

    bool grounded;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded) {
            Vector3 spawn = new Vector3(Random.Range(-2, 9), 8, 0);
            transform.position = spawn;
            _rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(Vector3.forward * 0); 
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy") {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
        if (other.gameObject.CompareTag("Ground"))
            grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            grounded = false;
    }

}
