using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawsManager : MonoBehaviour
{

    [SerializeField] HUDManager hudManager;

    private int numberOfPaws = 0;
    public int maxNumberOfPaws = 3;

    public void UpdateMaxPaws()
    {

        maxNumberOfPaws = GameManager.Instance.levelData.maxPaws;

    }

    public void AddPaw()
    {
        
        numberOfPaws++;
        hudManager.UpdatePawsText(numberOfPaws);

    }

    public int ReturnCurrentPaws()
    {

        return numberOfPaws;

    }

}
