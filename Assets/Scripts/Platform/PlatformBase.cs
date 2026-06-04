using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;

public abstract class PlatformBase : MonoBehaviour
{
    public Vector3 Delta { get; protected set; }

    [SerializeField] protected float _speed;
    [SerializeField] protected bool _moveHorizontal;
    [SerializeField] protected Transform[] _horizontalPoints;
    [SerializeField] protected Transform[] _verticalPoints;
    protected bool _moveRight, _moveUp;
    protected int _horizontalIndex, _verticalIndex;
    protected Vector3 _oldPosition, _newPosition;
    protected float _timeLeft, _fullTime;
    protected Rigidbody _rb;

    [Inject]
    protected void Construct(ISubscriber<ScreenStateChangedMessage> screenStateChanged)
    {
        _rb = GetComponent<Rigidbody>();

        DisposableBag.Create(
            screenStateChanged.Subscribe(HandleScreenStateChangedMessage)
        ).AddTo(destroyCancellationToken);
    }

    protected void Start()
    {
        NextPoint();
    }

    protected void FixedUpdate()
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
            {
                _horizontalIndex = GetNextIndex(
                    _horizontalIndex, _horizontalPoints.Length, ref _moveRight);
            }
            else
            {
                _verticalIndex = GetNextIndex(
                    _verticalIndex, _verticalPoints.Length, ref _moveUp);
            }

            NextPoint();
        }
    }

    protected void HandleScreenStateChangedMessage(ScreenStateChangedMessage message)
    {
        if (message.PlatformName == gameObject.name)
        {
            _moveHorizontal = !_moveHorizontal;
            NextPoint();
        }
    }

    protected int GetNextIndex(int i, int length, ref bool dir)
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

    protected abstract void NextPoint();
}
