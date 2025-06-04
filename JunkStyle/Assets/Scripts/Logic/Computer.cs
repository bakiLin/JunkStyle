using UnityEngine;
using Zenject;

public class Computer : MonoBehaviour
{
    [Inject]
    private AudioManager audioManager;

    [Inject]
    private LevelManager levelManager;

    [SerializeField]
    private int nextLevelIndex;

    public void LoadLevel()
    {
        audioManager.Play("revive", .1f);
        levelManager.LoadLevel(nextLevelIndex);
    }
}
