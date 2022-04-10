using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationButton : MonoBehaviour
{
    [SerializeField]
    private GameObject allCubes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateRight()
    {
        var tempRotation = allCubes.transform.rotation.eulerAngles;
        tempRotation += new Vector3(0, -90, 0);
        allCubes.transform.rotation = Quaternion.Euler(tempRotation);
    }

    public void RotateLeft()
    {
        var tempRotation = allCubes.transform.rotation.eulerAngles;
        tempRotation += new Vector3(0, 90, 0);
        allCubes.transform.rotation = Quaternion.Euler(tempRotation);
    }
}
