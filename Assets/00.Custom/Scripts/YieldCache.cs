using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace Custom
{
    public static class YieldCache
    {
        
        private static readonly Dictionary<float, YieldInstruction> _scaledCache;
        private static readonly Dictionary<float, CustomYieldInstruction> _unScaledCache;
        private static readonly Dictionary<Func<bool>, CustomYieldInstruction> _predicateCache;
        private static readonly YieldInstruction _fixed;
        private static readonly YieldInstruction _endFrame;
        
        public static YieldInstruction Null => null;
        public static YieldInstruction WaitForFixedUpdate() => _fixed;
        public static YieldInstruction WaitForEndOfFrame() => _endFrame;
        
        static YieldCache()
        {
            _scaledCache = new Dictionary<float, YieldInstruction>(new FloatComparer());
            _unScaledCache = new Dictionary<float, CustomYieldInstruction>(new FloatComparer());
            _predicateCache = new Dictionary<Func<bool>, CustomYieldInstruction>();
            _fixed = new WaitForFixedUpdate();
            _endFrame = new WaitForEndOfFrame();
        }
        
        public static YieldInstruction WaitForSeconds(float key)
        {
            if (_scaledCache.TryGetValue(key, out var value)) return value;
            YieldInstruction newValue = new WaitForSeconds(key);
            _scaledCache.TryAdd(key, newValue);
            return newValue;
        }

        public static CustomYieldInstruction WaitForSecondsRealTime(float key)
        {
            if (_unScaledCache.TryGetValue(key, out var value)) return value;
            CustomYieldInstruction newValue = new WaitForSecondsRealtime(key);
            _unScaledCache.TryAdd(key, newValue);
            return newValue;
        }

        public static CustomYieldInstruction WaitUntil(Func<bool> predicate)
        {
            if (_predicateCache.TryGetValue(predicate, out var value)) return value;
            CustomYieldInstruction newValue = new WaitUntil(predicate);
            _predicateCache.TryAdd(predicate, newValue);
            return newValue;
        }
    }
}
