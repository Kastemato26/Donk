using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private Transform throwPoint;
    public GameObject fireBall;
    // Start is called before the first frame update
    void Start()
    {
        throwPoint = transform;
    }

    // Update is called once per frame
    void Update()
    {
        ThrowBall();
    }
    void ThrowBall()
    {
        Instantiate(fireBall, throwPoint.position, throwPoint.rotation);
    }
}
