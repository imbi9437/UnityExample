using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public AnimationCurve curve;
    public SpriteRenderer renderer;

    private float EffectTime;
    
    public Gradient Gradient;
    private void Update()
    {
        EffectTime += Time.deltaTime;
        renderer.color = Gradient.Evaluate(curve.Evaluate(EffectTime));

        if (EffectTime > 1) EffectTime = 0f;
    }
}
