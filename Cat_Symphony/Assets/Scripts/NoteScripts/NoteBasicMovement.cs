using UnityEngine;

public class NoteBasicMovement : MonoBehaviour
{

     public Transform transformObjective;
     public float moveSpeed;

    private void Start()
    {
        
        transform.LookAt(transformObjective);

    }

    private void Update()
    {

        transform.position += moveSpeed * Time.deltaTime * transform.forward;

    }

}
