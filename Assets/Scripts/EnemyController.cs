using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform playerTransform;                               //player reference for enemy
    public float rotateSpeed = 2.0f;
    public float rotateRadius = 5.0f;
    public float rotateAngle;

    void Start()                                                                         
    {
         rotateRadius = Vector3.Distance(transform.position, playerTransform.position);                                                                                 
    }

    void Update()
    {
        if (playerTransform != null)
        {
            rotateAngle += rotateSpeed * Time.deltaTime;

            float x = Mathf.Cos(rotateAngle) * rotateRadius;                     //calculate rotation angle
            float y = Mathf.Sin(rotateAngle) * rotateRadius;

            transform.position = playerTransform.position + new Vector3(x, y, 0);

            Vector3 direction = playerTransform.position - transform.position;                //look at player

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;               

            transform.rotation = Quaternion.Euler(0, 0, angle - 90);            //make the enemies actually look towards the player

            Vector3 enemy = new Vector3(transform.position.x, transform.position.y, 0);

            Vector3 player = new Vector3(playerTransform.position.x, playerTransform.position.y, 0);

            var distance = (player - enemy).sqrMagnitude;                         //calcuate distance

            rotateSpeed = distance * 0.5f;
        }


    }
}
//look at player: DONE
//rotate around player: DONE 
//change speed depending on distance: DONE