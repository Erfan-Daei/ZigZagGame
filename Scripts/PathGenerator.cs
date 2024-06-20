using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Box;
    public GameObject Point;
    public GameObject Diamond;

    private float DiamondTimer;

    void Update()
    {
        Generator();
        DiamondTimer += Time.deltaTime;
    }

    void Generator()
    {
        if (Vector3.Distance(Ball.transform.position, Point.transform.position) < 20)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Random.Range(0f, 1f) > 0.5f)
                {
                    GameObject NewBox = Instantiate(Box, new Vector3(Point.transform.position.x + 1, Point.transform.position.y, Point.transform.position.z), Quaternion.identity);
                    Point = NewBox;
                    Box = NewBox;

                    if (DiamondTimer > 3)
                    {
                        DiamondGenerator(NewBox.transform);
                        DiamondTimer = 0;
                    }
                }
                if (Random.Range(0f, 1f) < 0.5f)
                {
                    GameObject NewBox = Instantiate(Box, new Vector3(Point.transform.position.x, Point.transform.position.y, Point.transform.position.z + 1), Quaternion.identity);
                    Point = NewBox;
                    Box = NewBox;
                }
            }
        }
    }

    void DiamondGenerator(Transform Pos)
    {
        Instantiate(Diamond, new Vector3(Pos.position.x, Pos.position.y + 0.7f, Pos.position.z), Quaternion.identity);
    }
}
