using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    public string sceneToLoad;
    public SpriteRenderer targetSprite;

    private void OnMouseDown()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && sr.sprite == targetSprite.sprite)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
