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

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
