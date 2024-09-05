using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float moveSpeed = 50f;
    public float jumpForce = 99999999f;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVE BY PIXELS
        // if(Input.GetKey("left"))
        // {
        //     gameObject.transform.Translate(-50*Time.deltaTime, 0,0);
        // }

        // if(Input.GetKey("right"))
        // {
        //     gameObject.transform.Translate(50*Time.deltaTime, 0,0);
        // }
        //MOVE BY PIXELS
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if(rb.velocity.x > 0)
        {
             GetComponent<SpriteRenderer>().flipX = true; // Mirar a la derecha
            gameObject.GetComponent<Animator>().SetBool("MovingSides",true);
        }else if(rb.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false; // Mirar a la izquierda
            gameObject.GetComponent<Animator>().SetBool("MovingSides",true);
        }
        else 
        {
            gameObject.GetComponent<Animator>().SetBool("MovingSides",false);
        }
        

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Detener movimiento horizontal cuando no se presiona ninguna tecla
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            
        }
       
    }

     // Detectar si el personaje está en el suelo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


}
