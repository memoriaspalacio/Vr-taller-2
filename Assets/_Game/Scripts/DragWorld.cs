using UnityEngine;

public class RotarOnMouseDrag : MonoBehaviour
{
    public float sensibilidad = 5f;      // respuesta al arrastre
    public float desaceleracion = 5f;    // qué tan rápido se detiene la inercia

    private Vector3 velocidadRotacion;   // grados/seg: (x = sobre eje X, y = sobre eje Y)
    private bool arrastrando = false;    // estado de arrastre (sin Input.Get... en Update)

    void OnMouseDown()
    {
        arrastrando = true;
    }

    void OnMouseUp()
    {
        arrastrando = false;
    }

    void OnMouseDrag()
    {
        // Lectura del ratón (suave) con ejes
        float dx = Input.GetAxis("Mouse X") * sensibilidad;  // movimiento horizontal
        float dy = Input.GetAxis("Mouse Y") * sensibilidad;  // movimiento vertical

        // Rotación inmediata durante el arrastre
        transform.Rotate(Vector3.up, -dx, Space.World); // giro horizontal (Y)
        transform.Rotate(Vector3.right, dy, Space.World); // giro vertical (X)

        // Guardar velocidad angular en grados/seg para la inercia
        float dt = (Time.deltaTime > 0f) ? Time.deltaTime : 0.016f;
        velocidadRotacion = new Vector3(dy, -dx, 0f) / dt;
        // Nota: x = rotación alrededor de X (proviene de dy), y = alrededor de Y (proviene de -dx)
    }

    void Update()
    {
        // Aplicar inercia sólo si NO estamos arrastrando y aún queda velocidad
        if (!arrastrando && velocidadRotacion.sqrMagnitude > 0.0001f)
        {
            transform.Rotate(Vector3.up, velocidadRotacion.y * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.right, velocidadRotacion.x * Time.deltaTime, Space.World);

            // Desacelerar suavemente hacia 0
            velocidadRotacion = Vector3.Lerp(velocidadRotacion, Vector3.zero, desaceleracion * Time.deltaTime);
        }
    }
}
