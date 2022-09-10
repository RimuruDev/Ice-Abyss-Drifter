using RimuruDev;
using UnityEngine;

using static RimuruDev.Helpers.Tag;

public sealed class CharacterController : MonoBehaviour
{
    private GameDataContainer gameContainer;

    [SerializeField] private Joystick joystick;

    [SerializeField] private Transform player;

    [SerializeField] private GameObject effectTeleport;

    [SerializeField] private Transform[] pointStart;
    private int random;
    [Space]
    public SpriteRenderer characterSpriteRenderer;

    public static float speed = 7f;
    public static Transform playerPoint;

    private float timeStart = 7f;
    private float timeShot = 7f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        gameContainer = FindObjectOfType<GameDataContainer>();
    }

    private void Start()
    {
        timeStart = Random.Range(5, 12);
        timeShot = timeStart;
        random = Random.Range(0, pointStart.Length);
        rb = GetComponent<Rigidbody2D>();
        transform.position = pointStart[random].transform.position;

        if (characterSpriteRenderer == null)
            characterSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        movement = GetPlayerInput();

        // textX.text = transform.position.x.ToString() + " :X";
        // textY.text = transform.position.y.ToString() + " :Y";

        if (!(playerPoint == player))
            playerPoint = player;

        if (movement.x < 0)
            FlipX(false);

        if (movement.x > 0)
            FlipX(true);

        if (gameContainer.Cosmo >= 1f)
        {
            if (timeShot <= 0f)
            {
                transform.position = new Vector2(Random.Range(110, -110), Random.Range(70, 10));
                timeStart = Random.Range(5, 12);
                Instantiate(effectTeleport, gameObject.transform.position, Quaternion.identity);
                timeShot = timeStart;
            }
            else
            {
                timeShot -= Time.deltaTime;
            }
        }

        CharacterMotion();
    }

    public Vector2 GetPlayerInput() => new(joystick.Horizontal, joystick.Vertical);

    public void CharacterMotion() => rb.velocity = GetPlayerInput().normalized * speed;

    public void FlipX(bool isFlipX) => characterSpriteRenderer.flipX = isFlipX;

    public Transform GetCharacterTransform { get => player; private set => player = value; }
}