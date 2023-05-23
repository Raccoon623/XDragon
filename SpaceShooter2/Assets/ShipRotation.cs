using UnityEngine;

public class RotateOnKeyPress : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 0f, 10f);
    public Vector3 returnSpeed = new Vector3(0f, 0f, 5f);
    public Vector3 targetRotation = new Vector3(0f, 0f, -90f);

    private bool isRotatingClockwise = false;
    private bool isRotatingCounterClockwise = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isRotatingCounterClockwise = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isRotatingCounterClockwise = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isRotatingClockwise = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRotatingClockwise = false;
        }

        if (isRotatingCounterClockwise)
        {
            RotateObject(rotationSpeed);
        }
        else if (isRotatingClockwise)
        {
            RotateObject(-rotationSpeed);
        }
        else
        {
            ReturnToBaseRotation(returnSpeed);
        }
    }

    private void RotateObject(Vector3 speed)
    {
        transform.Rotate(speed * Time.deltaTime);
    }

    private void ReturnToBaseRotation(Vector3 speed)
    {
        Quaternion targetRotationQuat = Quaternion.Euler(targetRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotationQuat, speed.magnitude * Time.deltaTime);
    }
}