using UnityEngine;

public class Idle_Controller : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    public AudioClip jumpSound;   // เสียงกระโดด
    private AudioSource audioSource;

    float x;
    float sx;
    bool isGrounded = false;

    Animator am;
    Rigidbody2D rb;

    void Start()
    {
        am = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        sx = transform.localScale.x;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        am.SetFloat("speed", Mathf.Abs(x));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            am.SetBool("jump", true);
            isGrounded = false;

            // เล่นเสียงกระโดด
            if (jumpSound != null)
                audioSource.PlayOneShot(jumpSound);
        }

        if (x > 0)
            transform.localScale = new Vector3(sx, transform.localScale.y, transform.localScale.z);
        else if (x < 0)
            transform.localScale = new Vector3(-sx, transform.localScale.y, transform.localScale.z);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.collider.isTrigger)
        {
            isGrounded = true;
            am.SetBool("jump", false);
        }
    }
}