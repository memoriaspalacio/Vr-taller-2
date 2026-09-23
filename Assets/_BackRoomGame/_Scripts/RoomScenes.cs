using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomScenes : MonoBehaviour
{
    public string sceneName;
    
    public void IntroRoomScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
