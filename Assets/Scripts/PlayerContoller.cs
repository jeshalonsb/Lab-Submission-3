using Unity.Hierarchy;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float horizontalInput;
    public float playerSpeed = 8;
    public float leftScreenLimit = -8;
    public float rightScreenLimit = 8;

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2 (horizontalInput, 0) * Time.deltaTime * playerSpeed);

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, leftScreenLimit, rightScreenLimit);          //clamp the player to a specific area on screen

        transform.position = pos;
    }
}
