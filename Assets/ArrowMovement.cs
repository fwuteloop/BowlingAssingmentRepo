using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField]
    private int moveState;

    public Vector3 launchDirection;

    [SerializeField]
    private float speed;
    private Vector3 myPos;
    private Vector3 movement;

    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private Vector3 ballOffset;

    private GameStateManager gameStateManager;
    private LaunchBall launchBall;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = GameObject.FindObjectOfType<GameStateManager>();
        launchBall = GetComponent<LaunchBall>();
        moveState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMoveState(moveState);
        
    }

    public void ChangeMoveState(int state)
    {
        moveState = state;
    }

    void CheckMoveState(int state)
    {
        switch (state)
        {
            //Aiming the ball
            case 0:
                {
                    launchDirection.y = 0;
                    ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    ChangePosition();
                    KeepBall();
                    if (Input.GetKeyDown(KeyCode.Space))
                        moveState = 1;
                    break;
                }
            //Launching the ball
            case 1:
                {
                    launchBall.enabled = true;
                    launchDirection.y = transform.eulerAngles.y;
                    launchBall.SetRotation(launchDirection);
                    gameStateManager.ChangeGameState(1);
                    this.enabled = false;
                    break;
                }
        }
    }
    void ChangePosition()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime * -1, 0, 0);
        transform.Translate(movement);
        myPos = transform.position;
        if (transform.position.x < 11.04f)
            myPos.x = 11.04f;
        if (transform.position.x > 11.5f)
            myPos.x = 11.5f;
        myPos.z = 37.8f;
        transform.position = myPos;
    }
    void KeepBall()
    {
        ball.transform.position = transform.position + ballOffset;
    }
}
