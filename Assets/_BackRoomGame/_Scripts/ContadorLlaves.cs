using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorLlaves : MonoBehaviour
{
    [SerializeField] private int _llaves;
    [SerializeField] private TextMeshProUGUI _llavesText;
    public static ContadorLlaves singleton;
    public GameObject pantallaVictoria;
    public GameObject pantallaVictoria2;
    public Animator animPuerta;
    public GameObject exitBackroom;

    protected void Awake()
    {
        singleton = this;
        _llaves = 0;
    }

    protected void Start()
    {
        _llavesText.text = "" + _llaves;
        exitBackroom.SetActive(false);
    }

    public void SumarPuntaje(int valor)
    {
        if(_llaves < 3)
        {
            _llaves += valor;

            _llavesText.text = "" + _llaves + "/3";
        }

        if(_llaves == 3)
        {
            animPuerta.SetBool("onOpen", true);
            exitBackroom.SetActive(true);
            //pantallaVictoria.SetActive(true);
            //pantallaVictoria2.SetActive(true);
        }
        
    }
}
