using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class Required : PropertyAttribute
{
    public WarningType warningType;

    public Required(WarningType _warningType = WarningType.Error)
    {
        warningType = _warningType;
    }
}

public enum WarningType { InspectorWarning, Error }