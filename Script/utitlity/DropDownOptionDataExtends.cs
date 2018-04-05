using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DropDownOptionDataExtends<T> : Dropdown.OptionData {
    public T Data
    { get; set; }
}
