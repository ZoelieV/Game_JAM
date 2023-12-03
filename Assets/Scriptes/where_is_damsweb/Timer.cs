using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timer = 60f;
    private bool sceneChanged = false;
    public Text timerText;

    void Update()
    {
        if (!sceneChanged)
        {
            timer -= Time.deltaTime;

            timerText.text = Mathf.Round(timer).ToString() + "s";

            if (timer <= 0)
            {
                ChangeScene();
            }
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("lose_where_is_damsweb");
    }

    public void SceneChanged()
    {
        sceneChanged = true;
    }

    void DisplayTimer(float TimerToDisplay)
    {
        float seconds = Mathf.FloorToInt(TimerToDisplay % 60);

        timerText.text = string.Format("{1:00}s", seconds);
    }
}
