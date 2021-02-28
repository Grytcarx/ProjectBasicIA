using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    //Script de General
    General general;

    //Componentes del player
    GameObject player;
    GameObject handPlayer;
    PlayerMovement playerMovement;

    //Componentes de este gameobject (Enemy)
    Animator animator;
    Rigidbody2D rg;

    //Componentes de AttackArea de este gameobject (Enemy)
    GameObject attackArea;
    EnemyAttackArea enemyAttackArea;

    //Componentes de Hand de este gameobject (Enemy)
    GameObject hand;
    EnemyHand enemyHand;

    //Variables de verificación
    private bool bloqueando;

    //Dificultad del Enemy que va de 1 a 10
    private float dificultad;

    //Velocidad Movimiento
    float velocidadMovimiento;

    //vida
    TextMesh vidaText;
    int vida;

    void Start()
    {
        //Inicialización de general
        general = GameObject.FindGameObjectWithTag("General").GetComponent<General>();

        //Inicialización de las variables de verificación
        bloqueando = false;

        //Inicialización de la dificultad del Enemy
        dificultad = PlayerPrefs.GetFloat("EnemyLevel");

        //Inicialización de velocidad de movimiento
        velocidadMovimiento = 0.05f;

        //Inicialización d la vida
        vida = 10;

        //Inicialización del componente de TextMesh Vida
        vidaText = gameObject.transform.Find("Vida").GetComponent<TextMesh>();
        vidaText.text = vida.ToString();

        //Inicialización de los Componentes del player
        player = GameObject.FindGameObjectWithTag("Player");
        handPlayer = player.transform.Find("Hand").gameObject;
        playerMovement = player.GetComponent<PlayerMovement>();

        //Inicialización de los Componentes de este gameobject (Enemy)
        animator = gameObject.GetComponent<Animator>();
        rg = gameObject.GetComponent<Rigidbody2D>();

        //Inicialización de los Componentes de Hand de este gameobject (Enemy)
        hand = gameObject.transform.Find("Hand").gameObject;
        enemyHand = hand.GetComponent<EnemyHand>();
        enemyHand.animator = animator;
        enemyHand.dificultad = dificultad;
        enemyHand.segundosEntreGolpe = (1f / 10f) * (10 - dificultad) + 0.1f;

        //Inicialización de los Componentes de AttackArea de este gameobject (Enemy)
        attackArea = gameObject.transform.Find("AttackArea").gameObject;
        enemyAttackArea = attackArea.GetComponent<EnemyAttackArea>();
        enemyAttackArea.player = player;
        enemyAttackArea.enemyHand = enemyHand;
        enemyAttackArea.playerMovement = playerMovement;
        enemyAttackArea.tiempoReaccionGolpe = (1f / 10f) * (10-dificultad) + 0.1f;

    }

    private void Update()
    {
        if (general.playing)
        {
            transform.position = new Vector2(transform.position.x - velocidadMovimiento, transform.position.y);

        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == handPlayer)
        {
            if (Random.Range(1,10) <= dificultad)
            {
                animator.SetBool("Bloqueando", true);
                bloqueando = true;

            }
            else
            {
                vida--;
                rg.AddForce(new Vector2(1, 0) * 100);

                if (vida > 0)
                {
                    vidaText.text = vida.ToString();
                }
                else
                {
                    general.playing = false;
                    general.textoMensaje.text = "Ganaste!";

                }
            }    
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == handPlayer)
        {
            StartCoroutine("Desbloquear");
            bloqueando = false;

        }

    }


    private IEnumerator Desbloquear()
    {
        yield return new WaitForSeconds(0.1f);

        if (!bloqueando)
        {
            animator.SetBool("Bloqueando", false);
        }
    }

}
