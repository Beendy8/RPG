using System;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private Destroy _idestroy;
    [SerializeField] private PossibleLoot _lootList;
    [SerializeField] private float _randomOffset; //дизайнер тут назначит максимальное отклонение от позиции
    [SerializeField] private int _lootCount;

    private void Start()
    {
        _idestroy.Subscribe(Spawn);
    }
    private void OnDestroy()
    {
        _idestroy.Unsubscribe(Spawn);
    }
    private void Spawn()
    {
        Vector3 position = transform.position;
        for (int i = 0; i < _lootCount; i++)
        {
            Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * _randomOffset;
            Vector3 currentOffset = Vector3.zero;
            currentOffset.x = randomCircle.x;
            currentOffset.z = randomCircle.y;
            Instantiate(_lootList.GetRandomLoot(), position + currentOffset, Quaternion.identity);
        }
    }
}
