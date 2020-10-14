using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infos : MonoBehaviour
{
    public Tower.Type type;

    void Start()
    {
        Text priceText = transform.GetChild(0).GetComponent<Text>();
        Text rangeText = transform.GetChild(1).GetComponent<Text>();
        Text fireRateText = transform.GetChild(2).GetComponent<Text>();
        Text damageText = transform.GetChild(3).GetComponent<Text>();

        priceText.text = "Price: " + Manager.Instance.GetPrice(type);
        rangeText.text = "Range: " + Manager.Instance.GetRange(type);
        fireRateText.text = "FireRate: " + Manager.Instance.GetFireRate(type);
        damageText.text = "Damage: " + Manager.Instance.GetDamage(type);
    }
}
