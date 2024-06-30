using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class InteractionArea : MonoBehaviour
{
    [SerializeField]
    private Image[] images;

    [SerializeField]
    private TextMeshProUGUI[] text;

    private Tween tween;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Fade(0.5f, 1f, 0.1f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            Fade(0f, 0f, 0.1f);
    }

    private void Fade(float imageEndValue, float textEndValue, float duration)
    {
        tween.Kill();

        foreach (var image in images)
            tween = image.DOFade(imageEndValue, duration);

        foreach (var t in text)
            tween = t.DOFade(textEndValue, duration);
    }
}
