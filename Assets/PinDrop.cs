using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinDrop : MonoBehaviour
{
    ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void FixedUpdate()
    {
        if (transform.eulerAngles.z < -80 | transform.eulerAngles.z > 80)
        {
            if(scoreManager.turns == 1)
                scoreManager.turn1ScoreInt += 2;
            if(scoreManager.turns == 2)
                scoreManager.turn2ScoreInt += 2;
            this.enabled = false;
        }
    }
}
