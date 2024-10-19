using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        private readonly Dictionary<Type, IPlayerComponent> componentDictionary = new();
        private void Awake()
        {
            void InitializeComponent()
            {
                var componentList = GetComponentsInChildren<IPlayerComponent>(true).
                    ToList();
                componentList.ForEach(x => InitComponent(x));
            }
            InitializeComponent();
            //componentDictionary.Remove(typeof(PlayerMovement));
            print(GetPlayerComponent<PlayerMovement>());
            //print(GetPlayerComponent<PlayerMovement>());
        }
        private void Update()
        {
            void GetInput()
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GetPlayerComponent<PlayerMovement>().Jump();
                }
            }
            GetInput();
        }
        public T GetPlayerComponent<T>() where T : MonoBehaviour, IPlayerComponent
        {
            if (componentDictionary.TryGetValue(typeof(T), out IPlayerComponent value))
            {
                return value as T;
            }
            Debug.LogError("can't find component, reInitializing...");
            return InitComponent() as T;
        }
        private IPlayerComponent InitComponent(IPlayerComponent component = null)
        {
            if (component == null)
                component = GetComponentInChildren<IPlayerComponent>(true);
            componentDictionary.Add(component.GetType(), component);
            component.Init(this);
            return component;
        }

    }

}