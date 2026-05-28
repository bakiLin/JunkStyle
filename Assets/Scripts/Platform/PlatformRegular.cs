using UnityEngine;

public class PlatformRegular : PlatformBase
{
    protected override void NextPoint()
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
}
