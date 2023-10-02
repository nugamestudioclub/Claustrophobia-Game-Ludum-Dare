using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    private float targetAlpha = 255f;
    private Color i;

    // Start is called before the first frame update
    void Start()
    {
        i = this.gameObject.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = Mathf.Lerp(i.a, targetAlpha, 0.9f * Time.deltaTime);
        i = new Color(i.r, i.g, i.b, alpha);
        this.gameObject.GetComponent<Image>().color = i;
    }
}
