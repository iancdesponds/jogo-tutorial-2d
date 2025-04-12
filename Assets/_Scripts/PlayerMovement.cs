using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float speed;
    private AudioSource audio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (GameController.IsGameOver) return; // para o jogador

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);

        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (moveHorizontal > 0.05f)
            transform.localScale = new Vector3(5f, 5f, 5f);
        else if (moveHorizontal < -0.05f)
            transform.localScale = new Vector3(-5f, 5f, 5f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coletavel")
        {
            Destroy(other.gameObject);
            GameController.AddScore();
            audio.Play();
        }
    }
}
