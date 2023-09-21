using System.Threading;
using UnityEngine;

public class folow : MonoBehaviour
{
    public float movementSpeed;
    public float detectionDistance;

    private Transform player;
    private bool isChasing = false;

    public Animator walk;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Verifica a distância entre o inimigo e o jogador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Verifica se o jogador está dentro da distância de detecção
        if (distanceToPlayer <= detectionDistance)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        
        if(player.position.x > transform.position.x)
        {
            //Jogador está mais a direita
            transform.localScale = new Vector2(-1, transform.localScale.y);
        } 
        else if(player.position.x < transform.position.x)
        {
            //Jogador está a esquerda
            transform.localScale = new Vector2(1, transform.localScale.y);

        }


        // Movimenta o inimigo em direção ao jogador se estiver seguindo
        if (isChasing)
        {
            walk.SetTrigger("Walk");
            Vector2 targetPosition = new Vector2(player.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        }
    }
}
