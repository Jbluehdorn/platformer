using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;

    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    private float lookahead;

    private void Update()
    {
        // Room Camera
        //transform.position = Vector3.SmoothDamp(
        //    transform.position, 
        //    new Vector3(currentPosX, transform.position.y, transform.position.z), 
        //    ref velocity, 
        //    speed
        //);

        // Player Camera
        transform.position = new Vector3(player.position.x + lookahead, transform.position.y, transform.position.z);
        lookahead = Mathf.Lerp(lookahead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
