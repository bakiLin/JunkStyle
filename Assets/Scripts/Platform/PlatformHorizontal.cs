using UnityEngine;

public class PlatformHorizontal : PlatformBase
{
    protected override void NextPoint()
    {
        _oldPosition = transform.position;

        if (_moveHorizontal)
        {
            _newPosition = _horizontalPoints[_horizontalIndex].position;
            _newPosition.x = transform.position.x;
        }
        else
        {
            _newPosition = _verticalPoints[_verticalIndex].position;
            _newPosition.z = transform.position.z;
        }

        _fullTime = Vector3.Distance(_oldPosition, _newPosition) / _speed;
        _timeLeft = _fullTime;
    }
}
