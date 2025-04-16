using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image blackout;

    private void Start()
    {
        blackout.DOFade(0f, 1f);
    }
}
