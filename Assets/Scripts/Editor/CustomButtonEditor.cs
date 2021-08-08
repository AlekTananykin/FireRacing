using UnityEditor;
using UnityEditor.UI;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(CustomButton))]
public class CustomButtonEditor : ButtonEditor
{

    private SerializedProperty _interactableProperty;

    protected override void OnEnable()
    {
        _interactableProperty = serializedObject.FindProperty("m_Interactable");
    }


    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();

        var changeButtonType = new PropertyField(
            serializedObject.FindProperty(CustomButton.ChangeButtonType));

        var curveEase = new PropertyField(
            serializedObject.FindProperty(CustomButton.CurveEase));

        var duration = new PropertyField(
            serializedObject.FindProperty(CustomButton.Duration));

        var tweenLabel = new Label("Sttings Tween");
        var interactableLabel = new Label("Interactable");

        root.Add(tweenLabel);
        root.Add(changeButtonType);
        root.Add(curveEase);
        root.Add(duration);

        root.Add(interactableLabel);
        root.Add(new IMGUIContainer(OnInspectorGUI));

        return root;
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.PropertyField(_interactableProperty);
        EditorGUI.BeginChangeCheck();
        serializedObject.ApplyModifiedProperties();
    }
}
