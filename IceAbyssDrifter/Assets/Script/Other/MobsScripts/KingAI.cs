using UnityEngine;

public sealed class KingAI : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, CharacterController._playerPoint.transform.position, _speed * Time.deltaTime);

        FlipWithPlayer();
    }

    private void FlipWithPlayer()
    {
        if (CharacterController._playerPoint.transform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (CharacterController._playerPoint.transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}