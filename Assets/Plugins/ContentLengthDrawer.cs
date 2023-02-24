using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

[CustomPropertyDrawer(typeof(ContentLengthAttribute))]

public class ContentLengthDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();

        // Отображаем основную переменную
        EditorGUI.PropertyField(position, property, label);

        if (EditorGUI.EndChangeCheck())
        {
            // Получаем ссылку на объект, которому принадлежит данная переменная
            var targetObject = property.serializedObject.targetObject as MonoBehaviour;



            var content = GameObject.FindGameObjectWithTag("Content").GetComponent<RectTransform>();

            // Записываем значение длины контента в указанную переменную
            var lengthField = targetObject.GetType().GetField("contentLength");
            lengthField.SetValue(targetObject, content.sizeDelta.x);
        }
    }
}

