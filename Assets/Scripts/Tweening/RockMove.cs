using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RockMove : MonoBehaviour
{
    public GameObject rockStart;
    private Vector3 rockStartPos;
    private Quaternion rockStartRot;

    public GameObject rockEnd;
    private Vector3 rockEndPos;
    private Quaternion rockEndRot;

    public float duration = 2;

    // Start is called before the first frame update
    void Start()
    {
        rockStartPos = rockStart.transform.position;
        rockEndPos = rockEnd.transform.position;

        rockStartRot = rockStart.transform.rotation;
        rockEndRot = rockEnd.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUp()
    {
        transform.DOMove(rockEndPos, duration);
        transform.DORotateQuaternion(rockEndRot, duration);
    }

    public void MoveDown()
    {
        transform.DOMove(rockStartPos, duration);
        transform.DORotateQuaternion(rockStartRot, duration);
    }
}
