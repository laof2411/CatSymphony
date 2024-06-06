using UnityEngine;

public class NoteBasicMovement : MonoBehaviour
{

    [SerializeField] private Transform transformObjective;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        
        transform.LookAt(transformObjective);

    }

    private void Update()
    {

        transform.position += moveSpeed * Time.deltaTime * transform.forward;

    }

}
