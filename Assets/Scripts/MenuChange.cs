using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuChange : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private GameObject fadeImage;

    private float targetAlpha = 0f;
    private Color i;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        i = fadeImage.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = Mathf.Lerp(i.a, targetAlpha, 0.0005f);
        i = new Color(0f, 0f, 0f, alpha);
        fadeImage.GetComponent<Image>().color = i;
        if (i.a >= 5f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void PlayGame()
    {
        targetAlpha = 255f;
    }

    private void ExitGame()
    {
        Application.Quit();
    }

}
