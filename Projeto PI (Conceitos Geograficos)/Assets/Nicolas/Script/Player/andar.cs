using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class andar : MonoBehaviour
{
    [Header("RigidBody do player")]
    public Rigidbody2D fisica;
    // direção do player, variavel abaixo
    public static float filme;
    [Header("Velocidade do Player")]
    public float speed;
    [Header("Força do Pulo do Player")]
    public float jumpforce;
    private bool terra;
    [Header("Tranform dos pés do player")]
    public Transform correr;
    [Header("Layer da colisão com o chao")]
    public LayerMask chao;
    [Header("Animator do Player")]
    public Animator player;
    private bool facingRight;
    [Header("Vida maxima do Player")]
    public int maxHealth = 100;

    int currentHealth;

    public hearth healthBar;

    [Header("Game Controller")]
    public GameController gameController;

    [Header("Tela de Morte")]
    public GameObject morte;

    public float Force;
    public float Count;
    public float KBtime;
    public bool isKnouk;

    public Animator damageEffect;

    public Animator effectmaldicion;

    public AudioSource audio;

    [Header("Audio")]
    public AudioClip jump;
    public AudioClip gemido;
    public AudioClip walk;
    public AudioClip atk;


    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        player = GetComponent<Animator>();

        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        KnockBack();
    }
    public void TocaSom(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
    void KnockBack()
    {
        if (Count < 0)
        {
            Move();
        }
        else
        {
            if (!isKnouk == true)
            {
                fisica.velocity = new Vector2(-Force, Force);
            }
            if (!isKnouk == false)
            {
                fisica.velocity = new Vector2(Force, Force);
            }
        }
        Count -= Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        TocaSom(gemido);
        currentHealth -= damage;
        damageEffect.SetTrigger("Effect");
        healthBar.SetHealth(currentHealth);

        //player.SetTrigger("Hurt");
        //Jogar animaçao ferida

        if (currentHealth <= 0)
        {
            Die();
        }

    }
    public void Die()
    {
        Debug.Log("Player died!");

        player.SetBool("IsDead", true);
        // Animaçao de morte

        morte.SetActive(true);
        Time.timeScale = 0f;
        fisica.velocity = Vector2.zero;
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        fisica.gravityScale = 0;
        // Desativar o inimigo
    }

    #region movimentação do player
    // Update is called once per frame
    void Move()
    {
        terra = Physics2D.OverlapCircle(correr.position, 0.3f, chao);

        filme = Input.GetAxisRaw("Horizontal");

        player.SetBool("isMoving", filme != 0);
        if(filme != 0 && terra)
        {
        TocaSom(walk);
        }
        fisica.velocity = new Vector2(filme * speed, fisica.velocity.y);

        // Pulo do Personagem
        if (terra && Input.GetKeyDown(KeyCode.Space))
        {
            TocaSom(jump);
            fisica.velocity = Vector2.up * jumpforce;
            player.SetBool("Jump", true);
        }

        if (filme < 0 && !facingRight || filme > 0 && facingRight)
        {
            Flip(filme);
        }
    }
    #endregion movimentação do player

    #region Flip do Player
    void Flip(float filme)
    {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
    }
    #endregion Flip do Player

    void OnCollisionEnter2D(Collision2D collsion)
    {
        Debug.Log("Eu colidi com algo" + collsion.collider.name);

        if (collsion.collider.CompareTag("Inimigo") == true)
        {
            TakeDamage(collsion.gameObject.GetComponent<combateEnemy>().attackDamage);
            //liga a tela, variavel gameobject que ira ativa aqui
        }
        if (collsion.collider.CompareTag("Ground"))
        {
            player.SetBool("Jump", false);
        }
        if (collsion.collider.CompareTag("espinho") == true)
        {
            morte.SetActive(true);
            Time.timeScale = 0f;
            fisica.velocity = Vector2.zero;
            this.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            fisica.gravityScale = 0;
            player.SetBool("IsDead", true);
        }
        
    }
}
