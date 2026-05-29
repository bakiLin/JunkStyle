using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private FirstPersonMovement _firstPersonMovement;
    [SerializeField] private SoundDataSO _stepSound;
    [SerializeField] private float _stepSoundInterval = 0.2f;
    [SerializeField] private float _runSoundInterval = 0.1f;
    private ISoundManager _soundManager;
    private bool _emittingStepSound;

    [Inject]
    private void Construct(ISoundManager soundManager)
    {
        _soundManager = soundManager;
    }

    private void Update()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (input.magnitude > .1f && _groundCheck.IsGrounded 
            && !_emittingStepSound && _firstPersonMovement.Rb.velocity != Vector3.zero)
            EmitStepSound().Forget();
    }

    private async UniTask EmitStepSound()
    {
        _emittingStepSound = true;
        await _soundManager.Get().Play(_stepSound, transform.position, destroyCancellationToken);

        if (!_firstPersonMovement.IsRunning)
            await UniTask.Delay((int)(_stepSoundInterval * 1000), cancellationToken: destroyCancellationToken);
        else
            await UniTask.Delay((int)(_runSoundInterval * 1000), cancellationToken: destroyCancellationToken);
        
        _emittingStepSound = false;
    }
}
