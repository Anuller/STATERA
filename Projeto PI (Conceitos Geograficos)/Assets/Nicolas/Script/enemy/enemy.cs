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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = vidaMaxima;
        barraVida.SetMaxHealth(vidaMaxima);
        rigidbody2 = GetComponent<Rigidbody2D>();   
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        barraVida.SetHealth(currentHealth);

        monster.SetTrigger("Hurt");
        //Jogar animaçao ferida

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Enemy died!");

        monster.SetBool("IsDead", true);
        // Animaçao de morte
        Destroy(gameObject);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        rigidbody2.gravityScale = 0;
        
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