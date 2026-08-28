using System.Collections.Generic;
using UnityEngine;

public class Descripciones : MonoBehaviour
{
    public GameObject casaClara;
    public GameObject lugarActivo;
    public List<GameObject> lugares = new List<GameObject>();
    private int contador;

    public static Descripciones singleton;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        contador = 1;
        AsignarId();
        //DesactivarInfoLugares();
        AsignarLugarActivo(lugares[0]);
        //lugares[0].SetActive(true); //para poner en corrutina
        
    }
    public void CasaClara()
    {
        casaClara.SetActive(true);
    }

    public void DesactivarInfoLugares()
    {
        foreach (GameObject lugar in lugares)
        {
            lugar.SetActive(false);
        }
    }

    public void ActivarLugarPorId(int id)
    {
        int idActivo = BuscarId(id);
        Debug.Log(idActivo);
        DesactivarLugarActivo();
        lugares[idActivo].SetActive(true);
        AsignarLugarActivo(lugares[idActivo]);
    }

    public void AsignarLugarActivo(GameObject lugar)
    {
        lugarActivo = lugar;
        Debug.Log(lugarActivo);
    }

    public void DesactivarLugarActivo()
    {
        lugarActivo.SetActive(false);
    }

    public int BuscarId(int id)
    {
        int idCodificado = id - 1;
        return idCodificado; 
    }

    public void AsignarId()
    {
        foreach (GameObject lugar in lugares)
        {
            EventoLugar eventoLugar = lugar.GetComponent<EventoLugar>();
            if(eventoLugar == null)
            {
                eventoLugar = lugar.AddComponent<EventoLugar>();
            }
            eventoLugar.id = contador;

            contador++;
        }
        
    }
}
