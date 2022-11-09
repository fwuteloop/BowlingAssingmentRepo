using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    private Animator directionAnimator;

    [SerializeField]
    private int gameState;

    [SerializeField]
    private GameObject cameraObj;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private Vector3 followOffset;
    [SerializeField]
    private Transform pos1;
    [SerializeField]
    private Transform pos2;

    [SerializeField]
    private GameObject restartButton;

    
    ArrowMovement arrowMovement;
    LaunchBall launchBall;
    // Start is called before the first frame update
    void Start()
    {

        arrowMovement = GameObject.FindObjectOfType<ArrowMovement>();
        launchBall = GameObject.FindObjectOfType<LaunchBall>();

        gameState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameState(gameState);

        if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(0);
    }

    public int GetGameState()
    {
        return gameState;
    }
    public void ChangeGameState(int state)
    {
        gameState = state;
    }

    void CheckGameState(int state)
    {
        switch (state)
        {
            //Aiming the ball;
            case 0:
                {
                    arrowMovement.enabled = true;
                    launchBall.enabled = false;
                    cameraObj.transform.position = pos1.position;
                    directionAnimator.SetBool("Aiming", true);
                    break;
                }
            //Launching the ball
            case 1:
                {
                    directionAnimator.SetBool("Aiming", false);
                    break;
                }
            //Ball reaches the end
            case 3:
                {
                    cameraObj.transform.position = pos2.position;
                    break;
                }
            //end of game; restart
            case 4:
                {
                    restartButton.SetActive(true);
                    break;
                }
        }
    }

    private void FixedUpdate()
    {
        if(GetGameState() == 1)
        {
            cameraObj.transform.position = ball.transform.position + followOffset;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
