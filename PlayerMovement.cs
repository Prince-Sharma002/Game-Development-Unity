using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(0,2)] float sideTransform;
    [SerializeField] [Range(0, 2)] float upwardTransform;
    [SerializeField] float sideForceImpulse;
    [SerializeField] float JumpForce;

    private Rigidbody2D rb;
    private bool isJump = false;

    float HorizontalMove;
    float VerticalMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (HorizontalMove == -1)
            rb.transform.localScale = new Vector2(-1f, 1f);
        if (HorizontalMove == 1)
            rb.transform.localScale = new Vector2(1f, 1f);


    }


    private void FixedUpdate()
    {
        // player Horizontal Movement
        HorizontalMove = Input.GetAxisRaw("Horizontal");
        rb.transform.position = rb.transform.position + new Vector3( HorizontalMove*sideTransform , 0, 0f);
        rb.AddForce(new Vector2(sideForceImpulse * HorizontalMove, 0f), ForceMode2D.Impulse);



        // Player Jump
        VerticalMove = Input.GetAxisRaw("Vertical");

        if (isJump == false && VerticalMove != 0f)
        {
            rb.AddForce(new Vector2(0f, JumpForce * VerticalMove), ForceMode2D.Impulse);
            rb.transform.position = rb.transform.position + new Vector3(0f, VerticalMove*upwardTransform , 0f);
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJump = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJump = true;
        }
    }

}
