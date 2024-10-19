using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RandomSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    private void Start()
    {
        int randomIndex = Random.Range(0 ,obstacles.Length);
        obstacles[randomIndex].SetActive(false);
    }
}
