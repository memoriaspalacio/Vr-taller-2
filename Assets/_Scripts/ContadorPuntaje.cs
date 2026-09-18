using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorPuntaje : MonoBehaviour
{
    [SerializeField] private int _puntaje;
    [SerializeField] private TextMeshProUGUI _puntajeText;
    public static ContadorPuntaje singleton;
    public GameObject pantallaVictoria;
    public GameObject pantallaVictoria2;

    protected void Awake()
    {
        singleton = this;
        _puntaje = 0;
    }

    protected void Start()
    {
        _puntajeText.text = "" + _puntaje;
    }

    public void SumarPuntaje(int valor)
    {
        if(_puntaje < 3)
        {
            _puntaje += valor;

            _puntajeText.text = "" + _puntaje;
        }

        if(_puntaje == 3)
        {
            pantallaVictoria.SetActive(true);
            pantallaVictoria2.SetActive(true);
        }
        
    }
}
