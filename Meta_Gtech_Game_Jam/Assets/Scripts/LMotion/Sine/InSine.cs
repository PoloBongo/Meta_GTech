using UnityEngine;
using LitMotion;
using LitMotion.Extensions;

public class InSince : MonoBehaviour
{
    [SerializeField] private Transform motionGameObject;
    [SerializeField] private float startPositionY = 0f;
    [SerializeField] private float endPositionY;

    private Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = transform.position;
    }

    private void Start()
    {
        transform.position = new Vector3(originalPosition.x, startPositionY, originalPosition.z);
        LMotion.Create(transform.position, new Vector3(transform.position.x, endPositionY, transform.position.z), 2f)
            .WithEase(Ease.InSine)
            .BindToPosition(motionGameObject);
    }
}
