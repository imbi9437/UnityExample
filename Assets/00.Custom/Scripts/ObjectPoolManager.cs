using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Custom
{
    public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
    {
        private Dictionary<Type, ObjectPool<GameObject>> _poolDic;

        protected override void Awake()
        {
            base.Awake();

            _poolDic = new Dictionary<Type, ObjectPool<GameObject>>();
        }
    }
}