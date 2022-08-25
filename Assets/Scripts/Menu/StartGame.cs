using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Button startButton;
    public Image fadeImage;
    private bool swappingScenes;

    void Start()
    {
        swappingScenes = false;
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        fadeImage.gameObject.SetActive(true);
        swappingScenes = true;
    }

    public void Update()
    {
        if (swappingScenes) {
            fade();
        }
    }

    void fade()
    {
        if(fadeImage.color.a < 0.95f)
        {
            Color color = fadeImage.color;
            color.a += 0.05f;
            fadeImage.color = color;
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
