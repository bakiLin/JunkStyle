using UnityEngine;

public class Computer : MonoBehaviour
{
    private AudioManager audioManager;

    private LevelManager levelManager;

    [SerializeField]
    private int nextLevelIndex;

    public void LoadLevel()
    {
        audioManager.Play("revive", .1f);
        levelManager.LoadLevel(nextLevelIndex);
    }
}
