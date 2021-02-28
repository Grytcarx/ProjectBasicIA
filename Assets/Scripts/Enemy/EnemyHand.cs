using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHand : MonoBehaviour
{
    //Componentes de este gameobject (Enemy)
    public Animator animator;

    //Variables de verificación
    public bool peleando;
    public bool atacarActivado;
    public float segundosEntreGolpe;

    //Dificultad
    public float dificultad;

    private void Start()
    {
        peleando = false;
        atacarActivado = false;

    }

    public IEnumerator Atacar()
    {
        animator.SetBool("Peleando", true);
        yield return new WaitForSeconds(0.05f);
        animator.SetBool("Peleando", false);
        yield return new WaitForSeconds(segundosEntreGolpe);

        StartCoroutine("VerificarSiPelear");

    }


    private IEnumerator VerificarSiPelear()
    {
        if (peleando)
        {
            if (Random.Range(1, 10) <= dificultad)
            {
                StartCoroutine("Atacar");

            }
            else
            {
                yield return new WaitForSeconds(segundosEntreGolpe);
                StartCoroutine("VerificarSiPelear");
            }
        }
        else
        {
            atacarActivado = false;
        }
    }

}
