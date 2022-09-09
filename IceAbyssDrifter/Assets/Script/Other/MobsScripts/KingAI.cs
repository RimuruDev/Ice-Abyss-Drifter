using UnityEngine;

public sealed class KingAI : MonoBehaviour
{
    [SerializeField] private float  speed;

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, CharacterController. playerPoint.transform.position,  speed * Time.deltaTime);

        FlipWithPlayer();
    }

    private void FlipWithPlayer()
    {
        if (CharacterController. playerPoint.transform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (CharacterController. playerPoint.transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}