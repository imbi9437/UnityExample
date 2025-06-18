using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace Custom
{
    public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
    {
        private Dictionary<Type, ObjectPool<IPoolingable>> _poolDic;

        protected override void Awake()
        {
            base.Awake();

            _poolDic = new Dictionary<Type, ObjectPool<IPoolingable>>();
        }
    }
}