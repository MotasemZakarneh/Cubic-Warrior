using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] HealthDisplay displayPrefab = null;
    [SerializeField] Transform displaysHead = null;

    List<HealthDisplay> displays = new List<HealthDisplay>();

    public void Add(Health health)
    {
        HealthDisplay display = Instantiate(displayPrefab, displaysHead);
        displays.Add(display);
        display.SetUp(health);
        display.SetNewData(health);

        health.onUpdated += OnHealthUpdate;
        health.onDead += OnDead;
        LayoutRebuilder.MarkLayoutForRebuild(displaysHead.GetComponent<RectTransform>());
    }

    private void OnDead(Health obj)
    {
        HealthDisplay display = displays.Find(o => o.IsOwner(obj));
        displays.Remove(display);
        Destroy(display.gameObject);
        LayoutRebuilder.MarkLayoutForRebuild(displaysHead.GetComponent<RectTransform>());
    }
    private void OnHealthUpdate(Health obj)
    {
        HealthDisplay display = displays.Find(o => o.IsOwner(obj));
        display.SetNewData(obj);
    }
}