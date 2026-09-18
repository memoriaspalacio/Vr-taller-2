using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Cronometro : MonoBehaviour
{
    [Header("Lista de Contenedores de calabazas")]
    [SerializeField] private List<GameObject> contenedores = new List<GameObject>();

    [Header("Tiempo")]
    [SerializeField] private float tiempoInicial = 5f;
    public float tiempoRestante;
    [SerializeField] private TextMeshProUGUI _timeText;

    [Header("Spawn")]
    [Tooltip("Prefab a instanciar cuando el tiempo llega a 0")]
    [SerializeField] private GameObject prefabAparecer;

    [Tooltip("Quién es el 'character' frente al cual aparecerá el prefab. Si lo dejas vacío, usa este mismo objeto.")]
    [SerializeField] private Transform character;

    [Tooltip("Distancia al frente del character")]
    [SerializeField] private float distanciaFrente = 2f;

    [Tooltip("Elevación opcional (por si el prefab debe aparecer un poco alto)")]
    [SerializeField] private float alturaOffset = 0f;

    [Tooltip("Alinear con el suelo por Raycast (requiere colisionadores)")]
    [SerializeField] private bool alinearAlSuelo = false;

    [SerializeField] private LayerMask sueloMask = ~0; // por defecto, todo

    protected void Awake()
    {
        tiempoRestante = tiempoInicial;

        // Si no asignaste el character, usamos el transform de este mismo objeto
        if (character == null)
            character = transform;
    }

    protected void Start()
    {
        StartCoroutine(CronometroCoroutine());
    }

    private IEnumerator CronometroCoroutine()
    {
        while (tiempoRestante > 0f)
        {
            ActualizarTexto();
            yield return new WaitForSeconds(1f);
            tiempoRestante = Mathf.Max(0f, tiempoRestante - 1f);
        }

        // Asegura que al llegar a 0 se muestre 00:00
        ActualizarTexto();

        // ¡Listo! Instanciamos el prefab frente al character
        SpawnFrenteCharacter();
    }

    private void ActualizarTexto()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
        if (_timeText != null)
            _timeText.text = $"{minutos:00}:{segundos:00}";
    }

    private void SpawnFrenteCharacter()
    {
        OcultarContenedores();

        if (prefabAparecer == null || character == null)
        {
            Debug.LogWarning("Falta asignar el prefabAparecer o el character en el inspector.");
            return;
        }

        // Posición base: frente al character según su forward
        Vector3 pos = character.position + character.forward * distanciaFrente;
        pos.y += alturaOffset;

        // Opcional: alinearlo con el suelo
        if (alinearAlSuelo)
        {
            // Tira un raycast hacia abajo desde un poco más alto por seguridad
            Vector3 origen = pos + Vector3.up * 2f;
            if (Physics.Raycast(origen, Vector3.down, out RaycastHit hit, 10f, sueloMask, QueryTriggerInteraction.Ignore))
            {
                pos = hit.point;
            }
        }

        // Rotación: mirando en la misma dirección que el character
        Quaternion rot = Quaternion.LookRotation(character.forward, Vector3.up);

        Instantiate(prefabAparecer, pos, rot);
    }

    private void OcultarContenedores()
    {
        foreach (GameObject contenedor in contenedores)
        {
            contenedor.SetActive(false);

        }
    }
}
