using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(DataBool))]
public class DataBoolDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        //return base.GetPropertyHeight(property, label);
        return EditorGUIUtility.singleLineHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect nameRect = new Rect(position.x, position.y, position.width / 3, position.height);
        Rect valueRect = new Rect(position.x + nameRect.width + 8, position.y, 18, position.height);

        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);
        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
