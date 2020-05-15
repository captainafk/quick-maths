using UnityEngine;

public class Player1_Controller : MonoBehaviour
{
    private Vector3 targetPos;
    private readonly double maxHeight = 3.5;
    private readonly double minHeight = 1.5;

    // Update is called once per frame
    private void Update()
    {
        if (GameMng.isGameRunning)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z < maxHeight)
            {
                targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                transform.position = targetPos;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z > minHeight)
            {
                targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                transform.position = targetPos;
            }
        }
    }
}