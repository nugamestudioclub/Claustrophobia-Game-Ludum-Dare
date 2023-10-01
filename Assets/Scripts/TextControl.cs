using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameStateManagement;

public class TextControl : MonoBehaviour
{
    [SerializeField]
    private string fullText;

    [SerializeField]
    private TextMeshProUGUI currentText;

    [SerializeField]
    private GameStateMachine gameState;

    // Start is called before the first frame update
    void Start()
    {
        currentText.text = "";
        StartCoroutine(WriteText());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentText.text.Equals(fullText))
            {
                gameState.Next();
            }
        }
    }

    IEnumerator WriteText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText.text += fullText[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
    }
}
