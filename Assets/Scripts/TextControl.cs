using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameStateManagement;

public class TextControl : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI currentText;

    [SerializeField]
    private GameStateMachine gameState;

    [SerializeField]
    private int order;

    private Color i;
    private float targetAlpha = 0f;
    private bool fade;

    private List<string> fullText = new List<string> { "You are an evil psychiatrist. Your 'patients' have been", "institutionalized for extreme claustrophobia.", "Make them feel small." };

    // Start is called before the first frame update
    void Start()
    {
        currentText.text = "";
        i = this.gameObject.GetComponent<TextMeshProUGUI>().color;
        fade = false;
        if (order == 0)
        {
            StartCoroutine(WriteText());
        }
        else 
        {
            StartCoroutine(Wait());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentText.text.Equals(fullText[order]))
            {
                fade = true;
                if (order == 2)
                {
                    gameState.Next();
                }
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

    IEnumerator Wait()
    {
        float value = 0f;
        for (int i = 0; i < fullText.Count; i++)
        {
            if (order == i)
            {
                StartCoroutine(WriteText());
            }
            else
            {
                value = fullText[i].Length * 0.05f;
            }
            yield return new WaitForSeconds(value);
        }
        yield return null;
    }

    IEnumerator WriteText()
    {
        for (int i = 0; i < fullText[order].Length; i++)
        {
            currentText.text += fullText[order][i];
            yield return new WaitForSeconds(0.05f * Time.deltaTime);
        }
        yield return null;
    }
}
