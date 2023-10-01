using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    private float targetAlpha = 0f;
    private Color i;
    private bool fade;

    // Start is called before the first frame update
    void Start()
    {
        i = this.gameObject.GetComponent<Image>().color;
        fade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            float alpha = Mathf.Lerp(i.a, targetAlpha, 0.9f * Time.deltaTime);
            i = new Color(0f, 0f, 0f, alpha);
            this.gameObject.GetComponent<Image>().color = i;

            if (i.a < 0.01f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void ChangeFade()
    {
        fade = !fade;
    }
}
