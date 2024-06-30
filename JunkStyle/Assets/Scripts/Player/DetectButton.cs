using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DetectButton : MonoBehaviour
{
    [SerializeField]
    private LayerMask button;

    [SerializeField]
    private Image image;

    [SerializeField]
    private TextMeshProUGUI text;

    private Tween tween;
    private bool temp;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.SphereCast(ray, 0.25f, out RaycastHit hit, 1.5f, button))
        {
            Button button = hit.transform.GetComponent<Button>();
            text.text = button.text;

            if (!temp) Fade(0.5f, 1f, 0.1f);
            temp = true;
        }
        else
        {
            if (temp) Fade(0f, 0f, 0.1f);
            temp = false;
        }
    }

    private void Fade(float imageEndValue, float textEndValue, float duration)
    {
        tween.Kill();
        tween = image.DOFade(imageEndValue, duration);
        tween = text.DOFade(textEndValue, duration);
    }
}
