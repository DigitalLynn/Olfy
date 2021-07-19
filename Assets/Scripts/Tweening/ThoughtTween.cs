using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ThoughtTween : MonoBehaviour
{
    public RawImage theImage;
    public List<Texture> images = new List<Texture>();
    public int index = 0;

    public void UIAppear()
    {
        transform.DOScale(1f, 0.5f);
    }
    public void UIDisappear()
    {
        transform.DOScale(0f, 0.5f);
    }

    public void ChangeImage()
    {
        index++;
        theImage.texture = images[index];
    }
}
