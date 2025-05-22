using UnityEngine;

namespace StarterAssets
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerHealth : MonoBehaviour
    {
        [Header("Player Health and Fall Damage Settings")]
        [Range(0.1f, 1f)]
        [Tooltip("Starting health for the character.")]
        public float StartingHealth = 1.0f;

        [Range(0.1f, 1f)]
        [Space(3f)]
        [Tooltip("Starting health for the character.")]
        public float FallDamageTimeThreshold = 0.2f;

        // player
        [SerializeField]
        private float _fallingThreshold;
        private CharacterController _controller;

        [SerializeField]
        private float _currentHealth;
        private bool _isFalling;

        public float Health
        {
            get { return _currentHealth; }
            set { _currentHealth = value; }
        }

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _fallingThreshold = FallDamageTimeThreshold;
            _currentHealth = StartingHealth;
        }

        private void Update()
        {
            if (!_controller.isGrounded)
            {
                _fallingThreshold -= Time.deltaTime;
            }
            else
            {
                _fallingThreshold = FallDamageTimeThreshold;
                if (_isFalling)
                {
                    _isFalling = false;
                    _currentHealth -= 0.1f;
                }
            }
            if (_fallingThreshold <= 0f)
            {
                _isFalling = true;
            }
        }
    }
}
