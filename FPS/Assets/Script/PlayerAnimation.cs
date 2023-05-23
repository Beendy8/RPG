using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerAnimation : MonoBehaviour
{
    private const string ApplyDamageTrigger = "ApplyDamage";
    private const string MakeDamageTrigger = "MakeDamage";
    private const string ForwardAnimation = "Forward";
    private const string RightAnimation = "Right";
    private const string AttackAnimation = "Attack";
    [SerializeField] private Player _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _playerModel; 
    private Transform _mainCamera;
    private void Start()
    {
        _mainCamera = Camera.main.transform;

        _player.takeDamage += ApplyDamage;
        _player.setInputAxis += SetInputAxis;

        _player.attack += () => _animator.SetTrigger(AttackAnimation);
    }

    private void OnDestroy()
    {
        _player.takeDamage -= ApplyDamage;
        _player.setInputAxis -= SetInputAxis;

        _player.attack -= () => _animator.SetTrigger(AttackAnimation);
    }

    #region Damage

    private void ApplyDamage(int value)
    {
        _animator.SetTrigger(ApplyDamageTrigger);
    }
    #endregion

    #region Move
    [Header("Move")]
    [SerializeField] private float _lerpValue = 2f;
    private float _forward;
    private float _right;
    private float _inputForward;
    private float _inputRight;
    public void SetInputAxis(float h, float v)
    {
        _inputForward = v;
        _inputRight = h;
    }
    private void Update()
    {
        RotateModel();
        SetAnimatorParameters();

    }

    private void RotateModel()
    {
        if (_inputForward == 0 && _inputRight == 0) return;

        Vector3 direction = _mainCamera.forward.normalized;
        direction.y = _playerModel.position.y;

        Vector3 forwardPoint = _playerModel.position + direction;

        Quaternion oldRotation = _playerModel.rotation;
        _playerModel.LookAt(forwardPoint);
        _playerModel.rotation = Quaternion.Lerp(oldRotation, _playerModel.rotation, 0.02f);
    }
    private void SetAnimatorParameters()
    {
        _forward = Mathf.Lerp(_forward, _inputForward, _lerpValue * Time.deltaTime);
        _right = Mathf.Lerp(_right, _inputRight, _lerpValue * Time.deltaTime);

        if (Mathf.Abs(_forward) < 0.001f) _forward = 0;
        if (Mathf.Abs(_right) < 0.001f) _right = 0;

        _animator.SetFloat(ForwardAnimation, _forward);
        _animator.SetFloat(RightAnimation, _right);
    }
    #endregion
}