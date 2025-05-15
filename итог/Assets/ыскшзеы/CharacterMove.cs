using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Vector3 input;
    public bool isGrounded;
    public int cherry;

    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer characterSprite;

    public AudioSource respSound;

    private SwitchController.ControlScheme currentScheme;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        // Получаем текущую схему управления из ControlSwitcher
        currentScheme = SwitchController.GetCurrentControlScheme();

        // Определяем ось в зависимости от схемы управления
        float horizontalInput = 0f;
        if (currentScheme == SwitchController.ControlScheme.WASD)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal_WASD");
        }
        else if (currentScheme == SwitchController.ControlScheme.Arrows)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal_Arrows");
        }

        // Движение персонажа
        input = new Vector2(horizontalInput, 0);
        transform.position += input * speed * Time.deltaTime;

        // Поворот спрайта в зависимости от направления движения
        if (input.x != 0)
        {
            characterSprite.flipX = input.x > 0 ? false : true;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public Transform respawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Traps")
        {
            transform.position = respawnPoint.position;
            rb.velocity = Vector2.zero;
            respSound.Play();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            transform.position = respawnPoint.position;
            rb.velocity = Vector2.zero;
            respSound.Play();
        }
    }
    private int coins = 0;
    public Text CoinText;
    private int coinsban = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cherry")
        {
            coins++;
            CoinText.text = coins.ToString("Вишенки: " + coins);
            Destroy(collision.gameObject);
            if (coins == 10)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (collision.gameObject.tag == "ban")
        {
            coinsban++;
            Destroy(collision.gameObject);
            if (coinsban == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
    }
}
