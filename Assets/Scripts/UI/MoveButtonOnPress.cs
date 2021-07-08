using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveButtonOnPress : MonoBehaviour
{
    public RectTransform buttonRect;

    private Vector2 startPos;

    public RectTransform target;

    private Vector2 targetPos;
    

    private float duration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = target.anchoredPosition;
        startPos = buttonRect.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hover()
    {
        buttonRect.DOAnchorPos(targetPos, duration);
    }

    public void Lift()
    {
        buttonRect.DOAnchorPos(startPos, duration);
    }
}
