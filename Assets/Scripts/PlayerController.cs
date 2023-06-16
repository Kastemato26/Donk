using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameController gameController;

    private Rigidbody2D body;
    // Input-muuttujat
    private float horizontalMovement;

    private float verticalMovement;


    // Liikkumismuuttujat
    private float moveSpeed = 5f;
    private Vector2 movement = new Vector2();

    //hypp‰‰mismuuttujat

    public float jumpForce = 5f;

    private bool grounded;

    // kiipe‰mismuuttujat
    private bool canClimb;

    private bool isClimbing;

    // animaatio

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        // Debug.Log(horizontalMovement);
        movement.x = horizontalMovement * moveSpeed;
        // hypp‰‰minen
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        // kiipe‰minen
        if (canClimb && verticalMovement != 0)
        {
            isClimbing = true;
        }
        else
        {
            isClimbing = false;
        }
        if (isClimbing)
        {
            movement.y = verticalMovement * moveSpeed;
            body.isKinematic = true;
        }
        else
        {
            movement.y = 0;
            body.isKinematic = false;
        }
        // hahmon k‰‰nt‰minen
        if (horizontalMovement > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (horizontalMovement < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        // animaatio  
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));
    }
    void FixedUpdate()
    {
        transform.Translate(movement * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = false;
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dragon"))
        {
            gameController.Win();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            gameController.Lose();
        }
    }
}