using UnityEngine.UI;
using UnityEngine;

public class pauseGame : MonoBehaviour
{

    [SerializeField]
    private Text pauseText;

    private void Start()
    {
        Time.timeScale = 1;
        pauseText.enabled = false;
    }

    public void pauseGameplay()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseText.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseText.enabled = false;
        }
    }
}
