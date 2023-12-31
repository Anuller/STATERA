using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator monster;
    public int vidaMaxima = 100;
    Rigidbody2D rigidbody2;

    //public static float filme;
    //private bool facingRight;

    // vida perdida
    int currentHealth;

    public hearth barraVida;

    public GameObject particula;

    //public AudioSource audioSound;

    //[Header("Audio")]
    //public AudioClip atk;
    //public AudioClip dead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = vidaMaxima;
        barraVida.SetMaxHealth(vidaMaxima);
        rigidbody2 = GetComponent<Rigidbody2D>();   
    }

    //public void TocaSom(AudioClip clip)
    //{
        //Debug.Log(dead);
        
        //audioSound.clip = clip;
        //audioSound.Play();
    //}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        barraVida.SetHealth(currentHealth);

        monster.SetTrigger("Hurt");
        //Jogar anima�ao ferida

        if (currentHealth <= 0)
        {
            //Debug.Log("fim");
            //TocaSom(dead);
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Enemy died!");

        //efeito de morte
        GameObject part = Instantiate(particula, transform.position, transform.rotation);
        Destroy(part, 0.4f);

        //gameObject.GetComponent<SpriteRenderer>().enabled = false;


        monster.SetBool("IsDead", true);

        // Anima�ao de morte
        //Destroy(part);
        Destroy(gameObject);

        //this.enabled = false;
        //GetComponent<Collider2D>().enabled = false;
        //rigidbody2.gravityScale = 0;
        
        // Desativar o inimigo
    }

   // void Flip(float filme)
    //{
        //facingRight = !facingRight;

        //Vector3 scale = transform.localScale;
       // scale.x *= -1;
        //transform.localScale = scale;
    //}

    private void Update()
    {
        //if (filme < 0 && !facingRight || filme > 0 && facingRight)
        //{
            //Flip(filme);
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") == true)
        {
            rigidbody2.velocity = Vector3.zero;
        }
    }

}