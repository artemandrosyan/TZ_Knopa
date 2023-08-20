using System;
using UnityEngine;

  public class HeroAnimator : MonoBehaviour
  {
    private const string SPEED = "Speed";
    [SerializeField] private HeroMove _heroMove;
    [SerializeField] private Animator _animator;

    private static readonly int SpeedHash = Animator.StringToHash(SPEED);

    private void Update()
    {
      _animator.SetFloat(SpeedHash, _heroMove.GetMagnitude(), 0.1f, Time.deltaTime);
    }



}
