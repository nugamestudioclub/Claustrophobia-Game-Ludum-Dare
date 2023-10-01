using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeImage;

    private float targetAlpha = 0f;
    private Color i;

    // Start is called before the first frame update
    void Start()
    {
        i = fadeImage.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = Mathf.Lerp(i.a, targetAlpha, 0.1f);
        i = new Color(0f, 0f, 0f, alpha);
        fadeImage.GetComponent<Image>().color = i;
        
        if (i.a < 0.01f)
        {
            fadeImage.SetActive(false);
        }
    }
}
