using Constants;
using GG.Events;
using UnityEngine;

/// <summary>
/// Attach to player/car game object to raise event when player/car reach the checkpoint
/// </summary>
public class CheckpointCollisionChecker : MonoBehaviour
{
    [Header("Raise Events")]
    [SerializeField] private StringEventChannelSO _eventPlayerReachCheckpoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.Checkpoint))
        {
            _eventPlayerReachCheckpoint.RaiseEvent(gameObject.tag);
        }
    }
}