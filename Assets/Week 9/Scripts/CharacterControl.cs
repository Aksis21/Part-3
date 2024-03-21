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

    //This is stupid. But, it works. This function is altered directly by the slider, and passes
    //the slider's value to a public float located in the Villager function if and ONLY if there
    //is a selected villager. Without this check for a null reference, Unity would give an error.
    public void SetVillagerScale(float value)
    {
        if (SelectedVillager != null)
        {
            SelectedVillager.scaler = value;
        }
    }

    //private void Update()
    //{
    //    if(SelectedVillager != null)
    //    {
    //        currentSelection.text = SelectedVillager.GetType().ToString();
    //    }
    //}
}
