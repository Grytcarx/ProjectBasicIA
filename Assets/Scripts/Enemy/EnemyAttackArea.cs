using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    //Componentes del player
    public GameObject player;
    public PlayerMovement playerMovement;

    //Componentes de este gameobject (Enemy)
    public EnemyHand enemyHand;

    //Variables de verificación de este gameobject (Enemy()
    private bool playerEnRango;

    //Tiempo de reacción para el golpe
    public float tiempoReaccionGolpe;

    private void Start()
    {
        playerEnRango = false;
    }

    private void Update()
    {
        if (playerEnRango)
        {
            if (!playerMovement.bloqueando)
            {
                StartCoroutine("Atacar");

            }
            else
            {
                enemyHand.peleando = false;
            }
            
        }
        else
        {
            enemyHand.peleando = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerEnRango = true;
            
        }   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerEnRango = false;
            
        }
    }

    public IEnumerator Atacar()
    {
        yield return new WaitForSeconds(tiempoReaccionGolpe);
        enemyHand.peleando = true;
        if (!enemyHand.atacarActivado)
        {
            enemyHand.atacarActivado = true;
            enemyHand.StartCoroutine("VerificarSiPelear");

        }

    }
}
