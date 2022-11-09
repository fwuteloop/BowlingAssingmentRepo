using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    ArrowMovement arrowMovement;
    GameStateManager gameStateManager;
    ScoreManager scoreManager;

    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private GameObject ballResetPosition;

    bool ballCollided;
    float stateChangeTimer;

    // Start is called before the first frame update
    void Start()
    {
        arrowMovement = GameObject.FindObjectOfType<ArrowMovement>();
        gameStateManager = GameObject.FindObjectOfType<GameStateManager>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        if (ballCollided)
            stateChangeTimer += Time.deltaTime;
        if (stateChangeTimer > 4)
        {
            if (scoreManager.turns < 2)
            {
                arrowMovement.ChangeMoveState(0);
                ball.transform.position = ballResetPosition.transform.position;
                gameStateManager.ChangeGameState(0);
            }
            else
                gameStateManager.ChangeGameState(4);

            stateChangeTimer = 0;
            ballCollided = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            scoreManager.turns += 1;
            gameStateManager.ChangeGameState(3);
            ballCollided = true;
        }
    }


}
