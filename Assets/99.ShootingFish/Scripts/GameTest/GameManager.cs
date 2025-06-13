using System;
using UnityEngine;

public partial class GameManager : MonoSingleton<GameManager>
{
    public Player player;
    
    public float effectSpeed;
    public Gradient hitEffectGradient;
}