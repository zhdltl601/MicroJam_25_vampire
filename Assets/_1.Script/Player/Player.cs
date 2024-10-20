using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    [DefaultExecutionOrder(-100)]
    public class Player : MonoSingleton<Player>
    {
        [SerializeField] private float fuelReduceMultiplier;

        [SerializeField] private float fuelMeter;
        [SerializeField] private float speedMeter;
        [SerializeField] private float traveledUnit;
        public float GetSpeedMeter { get => speedMeter; }

        public bool IsPlayerDead { get; private set; }
        public static event Action<float> EventUnitChanged;
        public static event Action<float> EventSpeedChange;
        public static event Action        EventPlayerDead;
        public static event Action        EventPlayerDamaged;
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
        protected override void OnDestroy()
        {
            base.OnDestroy();
            void OnDispose()
            {
                var componentList = componentDictionary.ToList();
                componentList.ForEach(x => x.Value.Dispose(this));
            }
            OnDispose();
        }
        public void AddFuel(float value)
        {
            fuelMeter += value;
            EventFuelChange?.Invoke(fuelMeter);
            CalculateFuel();
        }
        public void TakeDamage(float value)
        {
            AddFuel(-value);
            EventPlayerDamaged?.Invoke();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetPlayerComponent<PlayerMovement>().Jump();
            }
            if (Input.GetMouseButton(0))
            {
                GetPlayerComponent<FlameThrower>().Fire();
                fuelReduceMultiplier = 2.5f;
            }
            if (Input.GetMouseButtonUp(0))
            {
                fuelReduceMultiplier = 1f;
            }
            
            speedMeter += fuelMeter > 0 ? Time.deltaTime : - Time.deltaTime;
            float speedMeterClamped = Mathf.Clamp(speedMeter, 0, Mathf.Infinity);
            speedMeter = speedMeterClamped;
            EventSpeedChange?.Invoke(speedMeter);

            traveledUnit += speedMeter * Time.deltaTime;
            EventUnitChanged?.Invoke(traveledUnit);

        }
        private IEnumerator CO_Fuel()
        {
            while (!IsPlayerDead)
            {
                yield return null;

                fuelMeter -= fuelReduceMultiplier * Time.deltaTime;
                EventFuelChange?.Invoke(fuelMeter);
                CalculateFuel();
            }
        }
        private void CalculateFuel()
        {
            void DeadCheck()
            {
                if (fuelMeter <= 0)
                {
                    IsPlayerDead = true;
                    fuelMeter = 0;
                    EventPlayerDead?.Invoke();
                    print("Dead");
                }
            }
            DeadCheck();
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
        public Transform GetPlayerTransform()
        {
            return GetPlayerComponent<PlayerMovement>().transform;
        }
    }

}