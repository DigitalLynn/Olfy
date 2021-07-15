using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HMDFader : MonoBehaviour
{
    public Material fadeMaterial;

    // Start is called before the first frame update
    public void FadeIn(float duration)
    {
        fadeMaterial.DOFade(0f, duration);
    }

    public void FadeOut(float duration)
    {
        fadeMaterial.DOFade(1f, duration);
    }
}
