using UnityEngine;
using System.Collections;

public class ScpBehaviour : MonoBehaviour
{
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ScpAnimation());

    }

    IEnumerator ScpAnimation()
    {
        while (true)
        {
            // Tiempo aleatorio SIN hacer el gesto
            float waitTime = Random.Range(5f, 15f);
            yield return new WaitForSeconds(waitTime);

            // Inicia el gesto
            animator.SetBool("onGesture", true);

            // El gesto siempre dura 6.28 segundos
            yield return new WaitForSeconds(6.28f);

            // Termina el gesto
            animator.SetBool("onGesture", false);
        }
    }
}
