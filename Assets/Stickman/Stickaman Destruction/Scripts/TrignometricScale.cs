using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrignometricScale : MonoBehaviour
{

    public Vector3 ScaleLimit;
    public Vector3 ScaleFrequency;
    Vector3 FinalScale;
    Vector3 StartScale;
    void Start()
    {
        StartScale = transform.localEulerAngles;
    }
    void Update()
    {
        FinalScale.x = StartScale.x + Mathf.Sin(Time.timeSinceLevelLoad * ScaleFrequency.x) * ScaleLimit.x;
        FinalScale.y = StartScale.y + Mathf.Sin(Time.timeSinceLevelLoad * ScaleFrequency.y) * ScaleLimit.y;
        FinalScale.z = StartScale.z + Mathf.Sin(Time.timeSinceLevelLoad * ScaleFrequency.z) * ScaleLimit.z;
        transform.localScale = new Vector3(FinalScale.x, FinalScale.y, FinalScale.z);
    }
}
