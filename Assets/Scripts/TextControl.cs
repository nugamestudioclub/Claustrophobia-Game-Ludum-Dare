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

    private Color i;
    private float targetAlpha = 0f;
    private bool fade;

    // Start is called before the first frame update
    void Start()
    {
        currentText.text = "";
        i = this.gameObject.GetComponent<TextMeshProUGUI>().color;
        fade = false;
        StartCoroutine(WriteText());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentText.text.Equals(fullText))
            {
                fade = true;
                gameState.Next();
            }
        }
        if (fade)
        {
            float alpha = Mathf.Lerp(i.a, targetAlpha, 0.9f * Time.deltaTime);
            i = new Color(255f, 255f, 255f, alpha);
            this.gameObject.GetComponent<TextMeshProUGUI>().color = i;

            if (i.a < 0.01f)
            {
                this.gameObject.SetActive(false);
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
