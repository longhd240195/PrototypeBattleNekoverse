using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    public Image icon;
    [SerializeField] private GameObject objOnLevel;
    public Enemy enemy;
    //public LevelData level;
    public bool isOnLevel;
    private void Start()
    {
        objOnLevel.SetActive(isOnLevel);
    }
}
