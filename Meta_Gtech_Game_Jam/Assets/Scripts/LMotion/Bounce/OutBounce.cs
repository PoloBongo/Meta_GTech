using UnityEngine;
using LitMotion;
using LitMotion.Extensions;

public class OutBounce : MonoBehaviour
{
    [SerializeField] private Transform motionGameObject;
    [SerializeField] private float startPositionY = 0f;
    [SerializeField] private float endPositionY;

    private Vector3 originalPosition;

    private void OnEnable()
    {
        originalPosition = transform.position;
        transform.position = new Vector3(originalPosition.x, startPositionY, originalPosition.z);
        LMotion.Create(transform.position, new Vector3(transform.position.x, endPositionY, transform.position.z), 2f)
            .WithEase(Ease.OutBounce)
            .BindToPosition(motionGameObject);
    }
}