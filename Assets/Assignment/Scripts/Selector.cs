using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public List<Tank> tankList = new List<Tank>();
    public static Tank selection {  get; private set; }

    public void chooseTank(Tank tank)
    {
        if (selection != null)
        {
            selection.selected(false);
        }
        selection = tank;
        selection.selected(true);
    }

    public void DropDown(int value)
    {
        chooseTank(tankList[value]);
    }
}
