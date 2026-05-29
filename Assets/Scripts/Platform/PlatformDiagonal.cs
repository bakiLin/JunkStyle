using UnityEngine;

public class PlatformDiagonal : PlatformBase
{
    protected override void NextPoint()
    {
        _oldPosition = transform.position;

        if (_moveHorizontal)
        {
            _newPosition = transform.position;
            _newPosition.z = _horizontalPoints[_horizontalIndex].position.z;
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
