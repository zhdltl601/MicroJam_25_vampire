using UnityEngine;
using System.Reflection;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance is null) _instance = Initialize();
            return _instance;
        }
    }
    private static T Initialize()
    {
        //CreateInstance

        GameObject gameObject = new(name:"Singleton_" + typeof(T).Name);
        T result = gameObject.AddComponent<T>();
        return result;
    }
    protected virtual void Awake()
    {
        var flag = typeof(T).GetCustomAttribute<MonoSingletonUsageAttribute>().Flag;
        if (flag.HasFlag(MonoSingletonFlags.DontDestroyOnLoad)) DontDestroyOnLoad(gameObject);

        if (_instance is not null)
        {
            Debug.LogError("[Unity]twoSingletons_" + typeof(T).Name);
            Destroy(gameObject);
            return;
        }
        print("-AwakeInit-" + typeof(T).Name);
        _instance = this as T;
    }
    protected virtual void OnDestroy()
    {
        if(_instance == this)
        {
            _instance = null;
        }
    }
}