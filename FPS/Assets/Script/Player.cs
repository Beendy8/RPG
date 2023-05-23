using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage
{
    [SerializeField] private PossibleLoot _so;
    [SerializeField] private float _speed = 3;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _camera;
    public Vector3 lastVelocity { get; private set; } = Vector3.forward;

    private float _inputH;
    private float _inputV;

    public event Action<float, float> setInputAxis;
    public event Action attack;
    public void SetInputAxis(float h, float v)
    {
        _inputH = h;
        _inputV = v;
        setInputAxis?.Invoke(h, v);
    }
    private void FixedUpdate()
    {
        PhysicMove();
    }
    private void PhysicMove()
    {
        Vector3 forward = _camera.forward;
        Vector3 right = _camera.right;

        Vector3 direction = (forward * _inputV + right * _inputH).normalized;
        direction *= _speed;
        direction.y = _rigidbody.velocity.y;
        _rigidbody.velocity = direction; 
    }

    [SerializeField] private float _rechargeTime = .5f;
    private bool _recharge = false;
    public event Action<int> takeDamage;
    public void TakeDamage(int damage)
    {
        _recharge = true;
        StartCoroutine(Recharge());
        takeDamage?.Invoke(damage);
    }

    private IEnumerator Recharge()
    {
        yield return new WaitForSeconds(_rechargeTime);
        _recharge = false;
    }

    public void Attack()
    {
        attack?.Invoke();
    }
}
