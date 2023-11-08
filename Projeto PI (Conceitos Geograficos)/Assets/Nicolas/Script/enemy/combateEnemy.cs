using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combateEnemy : MonoBehaviour
{
    [Header("Animator do attack do Inimigo")]
    public Animator enemy;
    public enemy enemyScript;

    // Faz referencia ao ponto de attack
    [Header("Referencia do Ponto de attack")]
    public Transform attackPoint;

    // Determina a disatncia do attack
    [Header("Ranger do attack")]
    public float attackRange = 0.5f;

    // Determina qual GameObject vai ter a interação com o ataque
    [Header("Layer do Inimigo")]
    public LayerMask playerMask;

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
            if (Input.GetButtonDown("Mouse X"))
            {
                Debug.Log(enemyScript.dead);
                enemyScript.TocaSom(enemyScript.atk);
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void Attack()
    {

        //Reproduzir uma animação de ataque
        enemy.SetTrigger("Attack");

        //Detectar inimigos ao alcance do ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);

        //Danifique-os
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy == null)
            {
                return;
            }
            else
            {
                // acessar o componente dos inimigos
                enemy.GetComponent<andar>().TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
