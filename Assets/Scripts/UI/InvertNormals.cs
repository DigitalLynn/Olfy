using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class InvertNormals : MonoBehaviour
{
    /// <summary>
    /// How to flip the normals. When looking at an object the vectors are assigned clockwise. This means the physical plane faces you.
    /// If they are assigned counter clockwise then the plane faces the opposite way
    /// 
    /// Using this for dark room to show credits and 
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;

        // Store normals in an array
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
            normals[i] = -1 * normals[i];

        mesh.normals = normals;



        // Proceeds to reverse the count of the Vector3's
        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] tris = mesh.GetTriangles(i);
            for (int j = 0; j < tris.Length; j += 3)
            {
                // Swap order of tris
                int temp = tris[j];
                tris[j] = tris[j + 1];
                tris[j + 1] = temp;
            }

            mesh.SetTriangles(tris, i);
        }
        
    }
}