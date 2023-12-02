using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    [SerializeField] private LayerMask platformMask;
    public bool isGrounded;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = GetComponent<Collider>() != null && (((1 << GetComponent<Collider>().gameObject.layer) & platformMask) != 0);
    }
    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
