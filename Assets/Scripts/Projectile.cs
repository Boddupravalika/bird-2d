using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpringJoint2D springJoint;
    private bool isPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
    }

    void Update()
    {
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.bodyType =  RigidbodyType2D.Kinematic;
    }
    private void OnMouseUp()
    {
        isPressed = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpringJoint2D>().enabled = false;
    }
}



