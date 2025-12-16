using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Intro31 : MonoBehaviour
{

    bool fade;
    bool Once;
    public Image FadeImage;
    void OnEnable()
    {
        fade = false;
        if (Once) return;
        FadeImage.color = new Color(1, 1, 1, 1);
    }

    void OnMouseDown()
    {
        fade = true;
    }
    float x = 1;
    void LateUpdate()
    {
        if (Once) return;
        if (fade)
        {
            x = Mathf.Lerp(x, 0, Time.deltaTime);
            FadeImage.color = new Color(1, 1, 1, x);
            if (x < 0.1f)
            {
                this.gameObject.SetActive(false);
                Once = true;
            }

        }
    }
}
