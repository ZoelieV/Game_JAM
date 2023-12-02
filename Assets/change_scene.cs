using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    public string sceneToLoad; // Nom de la scène à charger

    private void OnMouseDown()
    {
        // Charger la nouvelle scène
        SceneManager.LoadScene(sceneToLoad);
    }
}
