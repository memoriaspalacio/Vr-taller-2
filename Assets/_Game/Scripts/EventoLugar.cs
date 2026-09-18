using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class EventoLugar : MonoBehaviour
{
    public int id;
    public TMP_Text miTexto;
    public string textoAsignado;



    private void Start()
    {
        
    }

    public void AsignarTexto(string nuevoTexto)
    {
        if (miTexto != null)
        {
            miTexto.text = nuevoTexto;
        }
        else
        {
            Debug.LogWarning("No se asignó ningún TextMeshPro en el Inspector.");
        }
    }

    private void OnMouseDown()
    {
        //AsignarTexto(textoAsignado);
        Descripciones.singleton.ActivarLugarPorId(id);
    }
}
