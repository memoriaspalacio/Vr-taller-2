using UnityEngine;
using UnityEngine.SceneManagement;

public class BackRoomExit : MonoBehaviour
{

    public GameObject pantallaVictoria;
    public GameObject pantallaVictoria2;
    public string sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
