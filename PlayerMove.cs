using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    BoxCollider2D bc;
    float hor;
    public float movespeed = 5f;
    public Rigidbody2D rb2D;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    float jumpForce;
    [SerializeField] private LayerMask jumpLayer;

    private float SpeedUpDuration;
    private bool SpeadUp;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();

        SpeedUpDuration = 0;
        SpeadUp = false;
    }

    // Update is called once per frame
    void Update()
    {

        hor = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(hor * movespeed, rb2D.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(hor));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }
        if (IsGrounded())
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }

        if (hor > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (hor < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (SpeadUp)
        {
            SpeedUpDuration += Time.deltaTime;
            if (SpeedUpDuration >= 3)
            {
                movespeed = 5f;
                SpeedUpDuration = 0;
                SpeadUp = false;
            }
        }

    }
    bool IsGrounded()
    {

        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Falldection")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Weak Point")
        {
            Destroy(collision.gameObject);

        }
        if (collision.collider.tag == "SpeedUp")
        {
            SpeadUp = true;
            movespeed += 2f;
        }
    }
}
