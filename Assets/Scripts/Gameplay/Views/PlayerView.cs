using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Ease _easeType;

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public async UniTask PlayMoveToAnimationAsync(Vector3 position, CancellationToken token = default)
    {
        var moveTween = transform.DOMove(position, _speed).SetEase(_easeType);

        await moveTween.AwaitForComplete(cancellationToken: token);
    }

    public async UniTask PlayWinAnimationAsync(CancellationToken token = default)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1));
    }

    public async UniTask PlayLoseAnimationAsync(CancellationToken token = default)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1));
    }
}