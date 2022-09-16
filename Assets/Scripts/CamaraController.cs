using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    [Range(1,10)]

    public float smootherFactor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition = Target.position + Offset;
        var smootherPosition = Vector3.Lerp(transform.position, targetPosition, smootherFactor * Time.fixedDeltaTime);
        transform.position = smootherPosition;
    }
}
