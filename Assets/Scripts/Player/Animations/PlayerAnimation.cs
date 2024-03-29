using GameManager.PauseGame;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Player.Animation
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour, IPausedHandler
    {

        private Animator _playerAnimator;

        #region [Initialization]
        private void Awake()
        {
            _playerAnimator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            PauseGame.instance.AddList(this);
        }

        private void OnDisable()
        {
            PauseGame.instance.RemoveList(this);
        }
        #endregion

        public void MoveAnimation(Vector2 moveDirection)
        {
            _playerAnimator.SetFloat("Vertical", moveDirection.x);
            _playerAnimator.SetFloat("Horizontal", moveDirection.y);
        }


        public void AttackAnimation()
        {          
            _playerAnimator.SetTrigger("Attack");
        }

        public void IsPaused(bool isPaused)
        {
            _playerAnimator.enabled = !isPaused;
        }
    }
}