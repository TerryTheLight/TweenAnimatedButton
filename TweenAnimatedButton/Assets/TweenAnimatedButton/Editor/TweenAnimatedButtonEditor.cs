using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(TweenAnimatedButton))]
public class TweenAnimatedButtonEditor : ButtonEditor
{
    private SerializedProperty _preClickEventProperty;
    private SerializedProperty m_OnClickProperty;
    private SerializedProperty m_InteractableProperty;

    protected override void OnEnable()
    {
        base.OnEnable();

        // or any other private field
        //_preClickEventProperty = serializedObject.FindProperty("_onPreClick");
        m_OnClickProperty = serializedObject.FindProperty("m_OnClick");
        m_InteractableProperty = serializedObject.FindProperty("m_Interactable");
    }

    public override void OnInspectorGUI()
    {
        //EditorGUILayout.PropertyField(_preClickEventProperty);
        EditorGUILayout.PropertyField(m_OnClickProperty);
        EditorGUILayout.PropertyField(m_InteractableProperty);
        serializedObject.ApplyModifiedProperties();
    }

   
}
