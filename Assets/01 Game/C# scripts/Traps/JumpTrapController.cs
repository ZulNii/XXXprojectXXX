using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class JumpTrapController : TrapController
{
    [SerializeField] private JumpTrigger _jumpTrigger;
    [SerializeField] private GameObject jumpTarget;
    void Start()
    {
        _jumpTrigger.OnPlayerEnter += JumpPlayer;
    }
    
    private void JumpPlayer(GameObject player)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(player.transform.DOJump(jumpTarget.transform.position, 10,1,1f));
        OnTrapDestroy?.Invoke(gameObject);
    }
}
