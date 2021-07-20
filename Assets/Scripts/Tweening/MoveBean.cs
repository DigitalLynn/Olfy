using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveBean : MonoBehaviour
{
    // Getting all the gameobjects then setting their rotation/poistion for the tweening in the scenen manager

    public GameObject investigate2;
    private Vector3 investigate2Pos;
    private Quaternion investigate2Rot;

    public GameObject investigate1;
    private Vector3 investigate1Pos;
    private Quaternion investigate1Rot;

    public GameObject house;
    private Vector3 housePos;
    private Quaternion houseRot;

    public GameObject grassBean;
    private Vector3 grassPos;
    private Quaternion grassRot;

    // Setting the duration and rotation times for the tweening
    

    // Start is called before the first frame update
    void Start()
    {
        // Setting all the positions and rotations

        investigate2Pos = investigate2.transform.position;
        investigate1Pos = investigate1.transform.position;
        
        grassPos = grassBean.transform.position;

        investigate2Rot = investigate2.transform.rotation;
        investigate1Rot = investigate1.transform.rotation;
        
        grassRot = grassBean.transform.rotation;
    }

    /// <summary>
    /// These are the controls for Bean which are being controlled in the Scene Manager
    /// </summary>

    // Move bean from their current location
    public void BeanToHouse(float durationPos, float durationRot)
    {
        housePos = house.transform.position;
        houseRot = house.transform.rotation;

        transform.DOMove(housePos, durationPos);
        transform.DORotateQuaternion(houseRot, durationRot);
    }

    // Move bean from their current location to investigation one (where the orb used to be)
    public void BeanToInvest2(float durationPos, float durationRot)
    {
        transform.DOMove(investigate2Pos, durationPos);
        transform.DORotateQuaternion(investigate2Rot, durationRot);
    }

    // Move bean from their current location to investigation two (where the rock used to be)
    public void BeanToInvest1(float durationPos, float durationRot)
    {
        transform.DOMove(investigate1Pos, durationPos);
        transform.DORotateQuaternion(investigate1Rot, durationRot);
    }

    // Move bean from their current location to where Sprout is hiding (where the rock used to be)
    public void BeanToSprout(float durationPos, float durationRot)
    {
        transform.DOMove(grassPos, durationPos);
        transform.DORotateQuaternion(grassRot, durationRot);
    }
}
