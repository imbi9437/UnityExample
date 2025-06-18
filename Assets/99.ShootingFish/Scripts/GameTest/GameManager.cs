using System;
using Custom;
using UnityEngine;

public partial class GameManager : MonoSingleton<GameManager>
{
    public Player player;
    public Spawner spawner;
    
    public float effectSpeed;
    public Gradient hitEffectGradient;
}