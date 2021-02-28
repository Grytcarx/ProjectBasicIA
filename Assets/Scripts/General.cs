using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class General : MonoBehaviour
{
    public bool playing;

    GameObject panel;
    GameObject mensaje;
    GameObject botonRegresar;

    public Text textoMensaje;

    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        panel = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Panel").gameObject;
        mensaje = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Mensaje").gameObject;
        botonRegresar = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Regresar").gameObject;

        textoMensaje = mensaje.GetComponent<Text>();

    }

    private void Update()
    {
        if (playing == false)
        {
            panel.SetActive(true);
            mensaje.SetActive(true);
            botonRegresar.SetActive(true);

        }
    }

    public void IrAMenuPrincipal()
    {
        SceneManager.LoadScene("PrincipalScreen");

    }

}
