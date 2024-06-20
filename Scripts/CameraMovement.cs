using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 Run = new Vector3(1, 0, 0);
    private Vector3 Left = new Vector3(0, 0, 1);
    private Vector3 Right = new Vector3(1, 0, 0);
    public bool GoRight = true;

    public bool GameIsOver = false;
    public bool StartGame = false;
    Rigidbody CamRB;


    public float Speed = 2;
    float SpeedTimer;
    public GameManager GameManager;

    void Start()
    {
        CamRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (StartGame)
        {
            Move();
        }
        SpeedTimer += Time.deltaTime;
        SpeedUp();
    }

    void Move()
    {
        if (!GameIsOver)
        {
            if (GoRight)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.LeftArrow))
                {
                    Run = Left;
                    GoRight = false;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.RightArrow))
                {
                    Run = Right;
                    GoRight = true;
                }
            }
            transform.position += Run * Time.deltaTime * Speed;
        }
        else
        {
            
        }

    }

    void SpeedUp()
    {
        if (GameManager.Record % 50 == 0 && GameManager.Record != 0 && SpeedTimer > 1)
        {
            Speed = Speed + 0.75f;
            SpeedTimer = 0;
        }
    }

    public void PlayAfterPause()
    {
        if (GoRight)
        {
            Run = Left;
            GoRight = false;
        }
        else
        {
            Run = Right;
            GoRight = true;
        }
    }
}
