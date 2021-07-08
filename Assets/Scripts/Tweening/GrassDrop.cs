using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrassDrop : MonoBehaviour
{
    public GameObject start;
    public GameObject end;

    // Empty gameObject attached to the the prefab parent
    private Transform endTrans;
    private Transform startTrans;

    private void Start()
    {
        endTrans = end.transform;
        startTrans = start.transform;
    }

    /// <summary>
    /// Moves to the final location
    /// </summary>
    public void GrassDown()
    {
        transform.DOMove(endTrans.position, 3f);
        transform.DORotateQuaternion(endTrans.rotation, 3f);
    }

    public void GrassUp()
    {
        transform.DOMove(startTrans.position, 3f);
        transform.DORotateQuaternion(startTrans.rotation, 3f);
    }
}
