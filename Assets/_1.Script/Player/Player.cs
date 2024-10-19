using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Player : MonoSingleton<Player>
    {
        [SerializeField] private float fuelReduceMultiplier;

        [SerializeField] private float fuelMeter;
        [SerializeField] private float speedMeter;
        [SerializeField] private int hp;
        public float GetSpeedMeter { get => speedMeter; }

        public bool IsFuelIncreassing { get; private set; }
        public bool IsPlayerDead { get; private set; }
        public static event Action EventPlayerDamaged;
        public static event Action EventPlayerDead;
        public static event Action<float> EventFuelChange;

        private readonly Dictionary<Type, IPlayerComponent> componentDictionary = new();
        protected override void Awake()
        {
            base.Awake();
            void InitializeComponent()
            {
                var componentList = GetComponentsInChildren<IPlayerComponent>(true).
                    ToList();
                componentList.ForEach(x => InitComponent(x));
            }
            InitializeComponent();
            StartCoroutine(CO_Fuel());
            //componentDictionary.Remove(typeof(PlayerMovement));
        }
        public void AddFuel(float value)
        {
            fuelMeter += value;
            EventFuelChange?.Invoke(fuelMeter);
            CalculateFuel(fuelMeter -= value);
        }
        public void AddHp(int value)
        {
            hp += value;
            //EventPlayerDamaged;
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
            speedMeter += IsFuelIncreassing ? Time.deltaTime : -Time.deltaTime;
            GetInput();
        }
        private IEnumerator CO_Fuel()
        {
            while (!IsPlayerDead)
            {
                yield return null;

                var before = fuelMeter;
                fuelMeter -= fuelReduceMultiplier * Time.deltaTime;
                EventFuelChange?.Invoke(fuelMeter);
                CalculateFuel(before);
            }
        }
        private void CalculateFuel(float beforeFuel)
        {
            void DeadCheck()
            {
                if (fuelMeter <= 0)
                {
                    fuelMeter = 0;
                    EventPlayerDead?.Invoke();
                    print("Dead");
                }
            }
            bool IsFuelIncreassing()
            {
                return fuelMeter < beforeFuel;
            }
            DeadCheck();
            this.IsFuelIncreassing = IsFuelIncreassing();
        }
        public T GetPlayerComponent<T>() where T : MonoBehaviour, IPlayerComponent
        {
            if (componentDictionary.TryGetValue(typeof(T), out IPlayerComponent value))
            {
                return value as T;
            }
            Debug.LogError("can't find Player_Component, reInitializing...");
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