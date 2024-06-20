using UnityEngine;

public class CheckBallDrop : MonoBehaviour
{
    public Transform BallPos;

    void Update()
    {
        transform.position = new Vector3(BallPos.position.x, transform.position.y, BallPos.position.z);
    }
}
