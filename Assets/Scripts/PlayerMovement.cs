using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private float lastFrameFingerPositionX;
    private float moveInX;
    private Vector3 swerveAmount;

    [Space(10)]
    [SerializeField] private bool isRotate;

    [Space(10)]
    [SerializeField] private bool isClampX;
    [SerializeField] private float clampingBoundaryInX;

    [Header("Speed Components")]
    [SerializeField] private float speedInXAxis;
    [SerializeField] private float speedInYAxis;
    [SerializeField] private float speedInZAxis;

    public bool isMove = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
      
    }

    private void Update()
    {
        if (isMove)
        {
            SwerveHandler();

            rb.velocity = (new Vector3(SwerveAmount() * speedInXAxis, 0, speedInZAxis));

            if (isRotate)
            {
                if (SwerveAmount() != 0)
                    RotateToFinger();
                else
                    RotateToZero();
            }

            if (isClampX)
                ClampPosition();

        }
    }

    private void SwerveHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveInX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveInX = 0f;
        }

        swerveAmount.x = moveInX;
    }

    public float SwerveAmount()
    {
        return swerveAmount.x;
    }

    private void RotateToFinger()
    {
        var targetPos = new Vector3(SwerveAmount(), transform.position.y, transform.position.z + 1);

        Quaternion rotation = Quaternion.LookRotation(targetPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
    }

    private void RotateToZero()
    {
        var targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);

        Quaternion rotation = Quaternion.LookRotation(targetPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
    }

    private void ClampPosition()
    {
        var x = Mathf.Clamp(transform.position.x, -clampingBoundaryInX, clampingBoundaryInX);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }


}