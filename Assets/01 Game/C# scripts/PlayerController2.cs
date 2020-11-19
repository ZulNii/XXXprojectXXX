using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
   public event Action<Transform> OnEnemyTouch;

   private void OnCollisionEnter(Collision other)
   {
      if(other.transform.TryGetComponent<EnemyController>(out EnemyController enemyController))
      {
         OnEnemyTouch?.Invoke(other.transform);
      }
   }
}
