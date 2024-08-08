

using UnityEngine;

public abstract class BaseNoteScript : MonoBehaviour
{

    public bool hasPaw = false;
    public bool hasBeenInteractedWith = false;
    public int trailNumber;
    [SerializeField] internal GameObject pawObject;

    public virtual void Start()
    {

        if(hasPaw)
        {

            pawObject.SetActive(true);

        }

    }

    public virtual void CheckForPaw() 
    {

        if (hasPaw)
        {

            FindFirstObjectByType<PawsManager>().AddPaw();
            hasPaw = false;

        }
    
    }

}
