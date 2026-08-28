using System.Collections;
using UnityEngine;

public class TiempoEscena : MonoBehaviour
{
    public int tiempo = 25;
    public GameObject escena;
    void Start()
    {
        StartCoroutine(DesaparicionEscena(tiempo));
    }

    IEnumerator DesaparicionEscena(int time)
    {
        yield return new WaitForSeconds(time);
        escena.SetActive(false);

    }

    
}
