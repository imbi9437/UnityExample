using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float effectSpeed;
    public AnimationCurve effectCurve;
    public Gradient hitEffectGradient;

    private void Awake()
    {
        Instance = this;
    }
}
