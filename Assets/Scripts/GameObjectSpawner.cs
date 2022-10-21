using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{
    [SerializeField] private float _delay = 0;
    [SerializeField] private float _interval = 1;
    [SerializeField] private GameObject _prefab;

    private Vector3 _spawnPosition;

    private void Start()
    {
        _spawnPosition = transform.position;
        InvokeRepeating(nameof(Spawn), _delay, _interval);
    }

    public void Spawn()
    {
        var instant = Instantiate(_prefab);
        instant.transform.position = _spawnPosition;
    }
}
