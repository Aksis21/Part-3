using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public List<Tank> tankList = new List<Tank>();
    public static Tank selection {  get; private set; }

    public void chooseTank(Tank tank)
    {
        //If a tank is already selected, this disables it before enabling the
        //newly selected option.
        if (selection != null)
        {
            selection.selected(false);
        }

        //Sets the new selection value according to the dropdown selection and
        //activates its functionality.
        selection = tank;
        selection.selected(true);
    }

    public void DropDown(int value)
    {
        //Takes the dropdown value and converts it into selecting one of the tank options.
        chooseTank(tankList[value]);
    }
}
