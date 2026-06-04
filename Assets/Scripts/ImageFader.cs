using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine.UI;

public static class ImageFader
{
    public static async UniTask FadeImage(Image image, float targetAlpha, 
        float duration, CancellationToken token)
    {
        Tween tween = image.DOFade(targetAlpha, duration).SetUpdate(true);
        await tween.AsyncWaitForCompletion();
    }
}
