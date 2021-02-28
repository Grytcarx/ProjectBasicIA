using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    General general;

    int vida;

    float velocidadMovimiento;

    public bool bloqueando;

    Rigidbody2D rg;
    Animator animator;

    TextMesh vidaText;

    //Enemy
    GameObject enemy;
    GameObject handEnemy;

    // Start is called before the first frame update
    void Start()
    {
        //Inicialización de general
        general = GameObject.FindGameObjectWithTag("General").GetComponent<General>();

        //Inicializamos todos los componentes y variables
        vida = 10;

        vidaText = gameObject.transform.Find("Vida").GetComponent<TextMesh>();
        vidaText.text = vida.ToString();

        velocidadMovimiento = 0.05f;
        bloqueando = false;

        rg = gameObject.GetComponent<Rigidbody2D>();

        animator = gameObject.GetComponent<Animator>();

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        handEnemy = enemy.transform.Find("Hand").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
    	//Verificamos si el juego aún continúa
        if (general.playing)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector2(transform.position.x + velocidadMovimiento, transform.position.y);

            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector2(transform.position.x - velocidadMovimiento, transform.position.y);

            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                animator.SetBool("Peleando", true);
            }
            else
            {
                animator.SetBool("Peleando", false);
            }

            if (Input.GetKey(KeyCode.L))
            {
                bloqueando = true;
                animator.SetBool("Bloqueando", bloqueando);

            }
            else
            {
                bloqueando = false;
                animator.SetBool("Bloqueando", bloqueando);
            }

        } 
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == handEnemy)
        {
        	//Verificamos si el jugador no está bloqueando golpes, para continuar a realizar el daño
            if (!bloqueando)
            {
                vida--;
                rg.AddForce(new Vector2(-1,0)*100);

                if (vida > 0)
                {
                    vidaText.text = vida.ToString();

                }
                else
                {
                    general.playing = false;
                    general.textoMensaje.text = "Perdiste!";


                }
                
            }
        }
    }
}
