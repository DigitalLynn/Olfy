using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBeanUI : MonoBehaviour
{
    private float x = 1.5f;
    private float z = 1f;

    public void MoveBeansUI()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
