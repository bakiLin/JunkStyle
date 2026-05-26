using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;

public class PlatformRegular : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _moveHorizontal;
    [SerializeField] private Transform[] _horizontalPoints;
    [SerializeField] private Transform[] _verticalPoints;

    private bool _moveRight, _moveUp;
    private int _horizontalIndex, _verticalIndex;
    private Vector3 _oldPosition, _newPosition;
    private float _timeLeft, _fullTime;
    private Rigidbody _rb;

    public Vector3 Delta { get; private set; }

    [Inject]
    private void Construct(ISubscriber<ScreenStateChangedMessage> screenStateChanged)
    {
        _rb = GetComponent<Rigidbody>();

        DisposableBag.Create(
            screenStateChanged.Subscribe(HandleScreenStateChangedMessage)
        ).AddTo(destroyCancellationToken);
    }

    private void Start()
    {
        NextPoint();
    }

    private void FixedUpdate()
    {
        var oldPosition = _rb.position;
        _timeLeft -= Time.deltaTime;
        float percent = (_fullTime - _timeLeft) / _fullTime;

        var position = Vector3.Lerp(_oldPosition, _newPosition, percent);
        Delta = position - oldPosition;
        Delta = new Vector3(Delta.x, 0.01f, Delta.z);
        _rb.MovePosition(position);

        if (percent >= 1)
        {
            if (_moveHorizontal)
                _horizontalIndex = GetNextIndex(
                    _horizontalIndex, _horizontalPoints.Length, ref _moveRight);
            else
                _verticalIndex = GetNextIndex(
                    _verticalIndex, _verticalPoints.Length, ref _moveUp);

            NextPoint();
        }
    }

    private void HandleScreenStateChangedMessage(ScreenStateChangedMessage message)
    {
        if (message.PlatformName == gameObject.name)
        {
            _moveHorizontal = !_moveHorizontal;
            NextPoint();
        }
    }

    private void NextPoint()
    {
        _oldPosition = transform.position;

        if (_moveHorizontal)
        {
            _newPosition = _horizontalPoints[_horizontalIndex].position;
            _newPosition.y = transform.position.y;
        }
        else
        {
            _newPosition = transform.position;
            _newPosition.y = _verticalPoints[_verticalIndex].position.y;
        }

        _fullTime = Vector3.Distance(_oldPosition, _newPosition) / _speed;
        _timeLeft = _fullTime;
    }

    private int GetNextIndex(int i, int length, ref bool dir)
    {
        if (dir)
        {
            if (i == length - 1)
            {
                dir = false;
                return i - 1;
            }
            return i + 1;
        }
        else
        {
            if (i == 0)
            {
                dir = true;
                return i + 1;
            }
            return i - 1;
        }
    }
}
