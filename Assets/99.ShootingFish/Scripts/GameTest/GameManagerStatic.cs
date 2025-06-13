using System;
using UnityEngine;

public partial class GameManager
{
    private static GameManager _instance;
    
    private static object _lock = new object();
    private static bool _isApplicationQuit = false;

    public static GameManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_isApplicationQuit) return null;

                if (_instance == false) _instance = FindAnyObjectByType<GameManager>();
                if (_instance) return _instance;
                
                GameObject obj = new GameObject(nameof(GameManager));
                _instance = obj.AddComponent<GameManager>();
                return _instance;
            }
        }
    }

    private void OnApplicationQuit()
    {
        _isApplicationQuit = true;
    }
}
