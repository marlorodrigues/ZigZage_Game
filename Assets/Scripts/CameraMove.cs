using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField]
    private Transform ball;
    private Vector3 distance;
    [SerializeField]
    private float lerpValue;
    private Vector3 pos, targetPosition;


    void Start()
    {
        distance = ball.position - transform.position;
    }

    private void LateUpdate()
    {

        if (!BallController.GameOver)
            moveWithObject();

    }

    private void moveWithObject()
    {
        pos = transform.position;
        targetPosition = ball.position - distance;
        pos = Vector3.Lerp(pos, targetPosition, lerpValue);
        transform.position = pos;
    }
}
