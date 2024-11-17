using UnityEngine;
using UnityEditor;
using System.Reflection;

[InitializeOnLoad]
public class RequiredFieldsValidator
{
    static RequiredFieldsValidator()
    {
        EditorApplication.playModeStateChanged += (state) =>
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                DebugWarnings();
            }
        };
    }

    private static void DebugWarnings()
    {
        bool shouldPauseGame = false;
        MonoBehaviour[] monoBehaviours = GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            FieldInfo[] fields = monoBehaviour.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                Required requiredAttribute = field.GetCustomAttribute<Required>();

                if (requiredAttribute != null)
                {
                    object fieldValue = field.GetValue(monoBehaviour);

                    if (fieldValue.Equals(null) && requiredAttribute.warningType == WarningType.Error)
                    {
                        Debug.LogError($"The field {field.Name} is required.", monoBehaviour);
                        shouldPauseGame = true;
                    }
                }
            }
        }

        if (shouldPauseGame)
        {
            EditorApplication.ExitPlaymode();
        }
    }
}