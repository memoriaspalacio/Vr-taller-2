using UnityEngine;

public class ContenedorCalabazas : MonoBehaviour
{
    private int suma;

    private void Awake()
    {
        suma = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            //ContadorPuntaje.singleton.SumarPuntaje(suma);
            ContadorLlaves.singleton.SumarPuntaje(suma);
            Destroy(other.gameObject);
        }
    }
}
