using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText, healthText = null;
    Health owner = null;

    public void SetUp(Health health)
    {
        owner = health;
    }
    public bool IsOwner(Health obj)
    {
        return owner == obj;
    }
    public void SetNewData(Health health)
    {
        nameText.text = health.name;
        healthText.text = health.CurrHealth.ToString();
    }
}