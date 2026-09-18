using UnityEngine;

public class Reiniciar : MonoBehaviour
{
    public void ReiniciarEscena()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
