using UnityEngine;

public class AnimationSpeedController : MonoBehaviour
{
    [SerializeField] private float _speedIncreaseRate = 0.2f; // How much to increase the animation speed each second
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed = 4f; // The maximum speed the animation can reach

    [SerializeField] private Animator _animator; // Reference to the Animator component
    [SerializeField] private string _floatName; // Name of the animation clip whose speed to modify

    private void Start()
    {
        _speed = _animator.GetFloat(_floatName);
    }

    private void Update()
    {
        _speed += _speedIncreaseRate * Time.deltaTime;
        _speed = Mathf.Clamp(_speed, 0f, _maxSpeed);
        _animator.SetFloat(_floatName, _speed);
    }
}
