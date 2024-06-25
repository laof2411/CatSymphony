using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawsManager : MonoBehaviour
{

    [SerializeField] HUDManager hudManager;

    private int numberOfPaws = 0;

    public void AddPaw()
    {
        
        numberOfPaws++;
        hudManager.UpdatePawsText(numberOfPaws);

    }

}
