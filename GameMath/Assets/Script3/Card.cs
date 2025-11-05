using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    class CardInfo
    {
        public string name; public int damage, cost;
        public CardInfo(string n, int d, int c) { name = n; damage = d; cost = c; }
    }

    void Start()
    {
        var cards = new List<CardInfo>() {
            new("Quick Shot",6,2), new("Quick Shot",6,2),
            new("Heavy Shot",8,3), new("Heavy Shot",8,3),
            new("Multi Shot",16,5), new("Triple Shot",24,7)};

        int maxCost = 15, maxDamage = 0; List<CardInfo> best = null;
        int n = cards.Count;
        for (int i = 0; i < (1 << n); i++)
        {
            int cost = 0, dmg = 0; var combo = new List<CardInfo>();
            for (int j = 0; j < n; j++) if ((i & (1 << j)) != 0)
                {
                    cost += cards[j].cost; dmg += cards[j].damage; combo.Add(cards[j]);
                }
            if (cost <= maxCost && dmg > maxDamage) { maxDamage = dmg; best = combo; }
        }

        Debug.Log("=== 최적 조합 ===");
        foreach (var c in best) Debug.Log($"{c.name} (D:{c.damage}, C:{c.cost})");
        Debug.Log($"총 데미지: {maxDamage}");
    }
}
