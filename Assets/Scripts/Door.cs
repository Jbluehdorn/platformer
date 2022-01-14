using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform prevRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collission)
    {
        if(collission.tag == "Player")
        {
            if(collission.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
            }
            else
            {
                cam.MoveToNewRoom(prevRoom);
            }
        }
    }
}
