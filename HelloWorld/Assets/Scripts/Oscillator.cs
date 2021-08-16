using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [Header("Movement Parameters")]
    public Vector3 movementAxis;
    public float movementSpeed;
    public float movementDistance;

    public float distancePos;
    public float distanceNeg;
    public Vector3 position;

    [Header("Movement Positions")]
    public Vector3 startingPostion;
    public Vector3 posEnd;
    public Vector3 negEnd;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        // direction of movement
        direction = movementAxis.normalized;

        // precompute pisotions
        startingPostion = transform.position;
        posEnd = transform.position + (direction * movementDistance);
        negEnd = transform.position - (direction * movementDistance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        position = transform.position;
        distancePos = Vector3.Distance(transform.position, posEnd);
        distanceNeg = Vector3.Distance(transform.position, negEnd);
        // if we reach the bounds of the movements, reverse the direction vector
        if (Vector3.Distance(transform.position, posEnd) <= 0.03f
            || Vector3.Distance(transform.position, negEnd) <= 0.03f
            )
        {
            direction *= -1;
        }
        // move the platform
        if (gameObject.name == "Moving Platform 5.5 (1)")
            Debug.Log("New frame");
            Debug.Log(gameObject.name + direction * movementSpeed);
            Debug.Log(Time.deltaTime);
            Debug.Log(direction * movementSpeed * Time.deltaTime);

        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }
}
