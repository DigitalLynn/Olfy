using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPassOnScript : MonoBehaviour
{
    public GameObject Tuft1;
    public GameObject Tuft2;

    // I know it's sloppy but this then tells both objects to drop

    // Start is called before the first frame update
    public void GrassDown()
    {
        Tuft1.GetComponent<GrassDrop>().GrassDown();
        Tuft2.GetComponent<GrassDrop>().GrassDown();
    }

    public void GrassUp()
    {
        Tuft1.GetComponent<GrassDrop>().GrassUp();
        Tuft2.GetComponent<GrassDrop>().GrassUp();
    }
}
