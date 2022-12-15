using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public int health;
    public int points;

    [SerializeField]
    public int pointsPerConsecutiveHit;

    public bool isBallInPlay = false;

    private void Start()
    {
        isBallInPlay = false;
        health = 3;
    }


    private void Update()
    {
        if (health == 0)
        {
            Time.timeScale = 0;
        }
    }


}
