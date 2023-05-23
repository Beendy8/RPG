using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private int _damage;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadious = .5f;

    public void MakeDamage()
    {
        var colliders = Physics.OverlapSphere(_attackPoint.position, _attackRadious, _layerMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].attachedRigidbody && colliders[i].attachedRigidbody.TryGetComponent(out ITakeDamage takeDamageObject))
            {
                takeDamageObject.TakeDamage(_damage);
            }
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_attackPoint.position, _attackRadious);
    }
#endif
}
