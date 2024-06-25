

using UnityEngine;

public abstract class BaseNoteScript : MonoBehaviour
{

    public bool hasPaw = false;
    public bool hasBeenInteractedWith = false;

    public virtual void CheckForPaw() 
    {

        if (hasPaw)
        {

            FindFirstObjectByType<PawsManager>().AddPaw();
            hasPaw = false;

        }
    
    }

}
