using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fasterRotator: MonoBehaviour
{

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(45, 30, 15) * Time.deltaTime * 3);
    }
}
