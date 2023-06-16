using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private Transform throwPoint;

    public GameObject fireBall;

    // ajastin
    private float throwTimer;
    public float timeBetweenThrows = 3f;
    // Start is called before the first frame update
    void Start()
    {
        throwPoint = transform;
        throwTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        throwTimer += Time.deltaTime;
        if (throwTimer > timeBetweenThrows)
        {
            ThrowBall();
            throwTimer = 0f;
        }
    }
    void ThrowBall()
    {
        Instantiate(fireBall, throwPoint.position, throwPoint.rotation);
    }
}
