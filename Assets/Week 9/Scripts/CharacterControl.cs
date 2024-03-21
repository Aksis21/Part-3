using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentSelection;
    public static CharacterControl Instance;
    public List<Villager> villagerList = new List<Villager>();
    public static Villager SelectedVillager { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.currentSelection.text = villager.ToString();
    }

    public void DropDownSelection(int value)
    {
        SetSelectedVillager(villagerList[value]);
    }

    //private void Update()
    //{
    //    if(SelectedVillager != null)
    //    {
    //        currentSelection.text = SelectedVillager.GetType().ToString();
    //    }
    //}
}
