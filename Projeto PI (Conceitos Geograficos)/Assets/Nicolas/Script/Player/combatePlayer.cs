using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatePlayer : MonoBehaviour
{

    [Header("Animator do attack do Player")]
    public Animator player;
    public andar andarScript;

    // Faz referencia ao ponto de attack
    [Header("Referencia do Ponto de attack")]
    public Transform attackPoint;

    // Determina a disatncia do attack
    [Header("Ranger do attack")]
    public float attackRange = 0.5f;

    // Determina qual GameObject vai ter a interação com o ataque
    [Header("Layer do Inimigo")] 
    public LayerMask enemyLayers;

    [Header("Dano do Ataque")]
    public int attackDamage = 40;

    [Header("Tempo do Ataque")]
    public float attackRate = 2f;

    // armazena o momento em que vamos attack
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            andarScript.speed = 8;
            if (Input.GetButtonDown("Fire1"))
            {
                print("Atacou");
                andarScript.TocaSom(andarScript.atk);
                
                Attack();
                

                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void Attack()
    {
        //Reproduzir uma animação de ataque
        andarScript.speed = 0;
        player.SetTrigger("Attack");
        

        //andarScript.speed = 8;
        //Detectar inimigos ao alcance do ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Danifique-os
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy == null)
            {
                andarScript.speed = 8;
                return;
                //andarScript.speed = 8;

            }
            else
            {
                //andarScript.speed = 8;
                // acessar o componente dos inimigos
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
                //andarScript.speed = 8;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            
            return;
            //andarScript.speed = 8;
        }
        

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}