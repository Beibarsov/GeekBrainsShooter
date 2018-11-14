using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData {

    public string Name;
    public float HP;
    public bool IsVisible;

    public override string ToString()
    {
        return string.Format("Name: {0}, HP: {1}, IsVisible: {2}", Name, HP, IsVisible);
    }


}
