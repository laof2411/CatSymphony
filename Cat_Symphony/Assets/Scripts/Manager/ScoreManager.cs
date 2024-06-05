using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private HUDManager HUD;
    [SerializeField] private int currentScore;

    [SerializeField] private void UpdateScore()
    {

        currentScore += 5;

    }
    
}
