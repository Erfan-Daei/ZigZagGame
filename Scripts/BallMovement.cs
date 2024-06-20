using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector3 Run = new Vector3(1, 0, 0);
    private Vector3 Left = new Vector3(0, 0, 1);
    private Vector3 Right = new Vector3(1, 0, 0);
    public bool GoRight = true;

    public bool GameIsOver = false;
    public bool StartGame = false;
    Rigidbody BallRB;


    public float Speed = 2;
    float SpeedTimer;
    public GameManager GameManager;
    public AudioManager audioManager;

    public Animator animator;
    byte StartEffects = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        BallRB = GetComponent<Rigidbody>();
        if (!StartGame)
            animator.Play("Pause");
    }

    void Update()
    {
        if (StartGame)
        {
            Move();
            if (StartEffects == 0)
            {
                BallRB.isKinematic = false;
                if (GoRight)
                    animator.Play("BallRightRotate");
                else
                    animator.Play("BallLeftRotate");
                StartEffects++;
            }
        }
        else
        {
            animator.Play("Pause");
            StartEffects = 0;
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
                    animator.Play("BallLeftRotate");
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.RightArrow))
                {
                    Run = Right;
                    GoRight = true;
                    animator.Play("BallRightRotate");
                }
            }
            transform.position += Run * Time.deltaTime * Speed;
        }
        else
        {
            BallRB.isKinematic = true;
        }
        
    }

    void SpeedUp()
    {
        if (GameManager.Record % 50 == 0 && GameManager.Record != 0 && SpeedTimer > 1)
        {
            Speed = Speed + 0.75f;
            SpeedTimer = 0;
            audioManager.BackSource.pitch += .05f;
            animator.SetFloat("Speed", animator.GetFloat("Speed") + .75f);
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