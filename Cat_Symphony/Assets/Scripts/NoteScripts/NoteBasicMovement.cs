using UnityEngine;

public class NoteBasicMovement : MonoBehaviour
{

    public Transform transformObjective;
    public float moveSpeed;

    private void Start()
    {

        transform.LookAt(transformObjective);
        moveSpeed = GameManager.Instance.levelData.noteSpeed;

    }

    private void Update()
    {
        if (!GameManager.Instance.isPaused)
        {

            transform.position += moveSpeed * Time.deltaTime * transform.forward;


        }

    }

}
