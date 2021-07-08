using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveSprout : MonoBehaviour
{
    // Getting all the gameObjects then setting their rotation and position in the start

    public GameObject start;
    private Vector3 startPos;
    private Quaternion startRot;

    public GameObject investigate2;
    private Vector3 investigate2Pos;
    private Quaternion investigate2Rot;

    public GameObject investigate1;
    private Vector3 investigate1Pos;
    private Quaternion investigate1Rot;

    public GameObject house;
    private Vector3 housePos;
    private Quaternion houseRot;

    // Setting the duration and rotation times for the tweening
    private int durationPos = 3;
    private int durationRot = 1;

    // What scene are the current actors at
    private int sceneNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        startPos = start.transform.position;
        investigate2Pos = investigate2.transform.position;
        investigate1Pos = investigate1.transform.position;
        housePos = house.transform.position;

        startRot = start.transform.rotation;
        investigate2Rot = investigate2.transform.rotation;
        investigate1Rot = investigate1.transform.rotation;
        houseRot = house.transform.rotation;

        // Move bean to house
        transform.DOMove(startPos, durationPos);
        transform.DORotateQuaternion(startRot, durationRot);
    }

    public void SproutToInvest1_Quick()
    {
        transform.DOMove(investigate1Pos, durationRot);
        transform.DORotateQuaternion(investigate1Rot, durationRot);
    }

    public void SproutToInvest1_Slow()
    {
        transform.DOMove(investigate1Pos, durationPos);
        transform.DORotateQuaternion(investigate1Rot, durationRot);
    }

    public void SproutToInvest2_Quick()
    {
        transform.DOMove(investigate2Pos, durationRot);
        transform.DORotateQuaternion(investigate2Rot, durationRot);
    }
    public void SproutToInvest2_Slow()
    {
        transform.DOMove(investigate2Pos, durationPos);
        transform.DORotateQuaternion(investigate2Rot, durationRot);
    }

    public void SproutToHouse()
    {
        transform.DOMove(housePos, durationPos);
        transform.DORotateQuaternion(houseRot, durationRot);
    }
}
