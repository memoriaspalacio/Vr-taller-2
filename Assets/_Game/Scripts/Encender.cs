using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Encender : MonoBehaviour
{
    public List<GameObject> cardumenes = new List<GameObject>();
    public Image panelImage;        // arrástralo desde el Inspector
    public float duracion = 1.5f;   // segundos
    public void EncenderCardumen()
    {
        foreach (var cardumen in cardumenes)
        {
            cardumen.SetActive(true);
        }
    }

    public void FadeOut()           // alpha -> 0 (desaparecer)
    {
        // Asegura alpha inicial en 1 (visible)
        panelImage.canvasRenderer.SetAlpha(1f);
        panelImage.CrossFadeAlpha(0f, duracion, ignoreTimeScale: false);
    }
}
