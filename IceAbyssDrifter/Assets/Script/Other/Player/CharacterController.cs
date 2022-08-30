using UnityEngine;

using static RimuruDev.Helpers.Tag;

public sealed class CharacterController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private GameObject _effectTeleport;

    //[SerializeField] Text _textX;
    //[SerializeField] Text _textY;

    [SerializeField] private Transform[] _pointStart;
    private int _random;
    [Space]
    public SpriteRenderer characterSpriteRenderer;

    public static float _speed = 7f;
    public static Transform _playerPoint;

    private float _timeStart = 7f;
    private float _timeShot = 7f;

    private Rigidbody2D _rb;
    private Vector2 _movement;

    private void Awake()
    {
        _timeStart = Random.Range(5, 12);
        _timeShot = _timeStart;
        _random = Random.Range(0, _pointStart.Length);
        _rb = GetComponent<Rigidbody2D>();
        transform.position = _pointStart[_random].transform.position;

        if (characterSpriteRenderer == null)
            characterSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _movement = GetPlayerInput();

        //_textX.text = transform.position.x.ToString() + " :X";
        //_textY.text = transform.position.y.ToString() + " :Y";

        if (!(_playerPoint == _player))
            _playerPoint = _player;

        if (_movement.x < 0)
            FlipX(false);

        if (_movement.x > 0)
            FlipX(true);

        if (GameManager._cosmo >= 1f)
        {
            if (_timeShot <= 0f)
            {
                transform.position = new Vector2(Random.Range(110, -110), Random.Range(70, 10));
                _timeStart = Random.Range(5, 12);
                Instantiate(_effectTeleport, gameObject.transform.position, Quaternion.identity);
                _timeShot = _timeStart;
            }
            else
            {
                _timeShot -= Time.deltaTime;
            }
        }

        CharacterMotion();
    }

    public Vector2 GetPlayerInput() => new(Input.GetAxisRaw(Horizontal), Input.GetAxisRaw(Vertical));

    public void CharacterMotion() => _rb.velocity = GetPlayerInput().normalized * _speed;

    public void FlipX(bool isFlipX) => characterSpriteRenderer.flipX = isFlipX;

    public Transform GetCharacterTransform { get => _player; private set => _player = value; }
}