using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePosition : MonoBehaviour
{
    public void RotateHomePos()
    {
        transform.Rotate(-180, 90, -180);
    }
}
