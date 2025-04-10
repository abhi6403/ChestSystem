using ChestSystem.Chest;
using UnityEngine;

public class UIServices : MonoBehaviour
{
    public ChestSO chestSO;
    public ChestController chestController;
    
    [SerializeField] private Transform _contentTransform;
    public void CreateChest()
    {
        chestController = new ChestController(chestSO, _contentTransform);
    }
}
