using UnityEngine;

[CreateAssetMenu(menuName = "SO/Intro")]
public class SO_Intro : ScriptableObject
{
    [SerializeField] private string text;
    [SerializeField] private Sprite sprite;
    public string GetText => text;
    public Sprite GetSprite => sprite;
}
