using System;
using System.Collections;
using System.Collections.Generic;
using Bolt;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class CastleController : MonoBehaviour
{
   public event Action OnComplete;
   public int TNTCubesCount;
   protected int progress;
   
   public abstract void StartMinigame();
   protected void OnCompleteGame()
   {
      OnComplete?.Invoke();
   }
}