using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(TweenAnimatedButton))]
public class TweenAnimatedButtonEditor : ButtonEditor
{
    private SerializedProperty _disableTillTweenFinProperty;
    private SerializedProperty _onClickProperty;
    private SerializedProperty _interactableProperty;

    protected override void OnEnable()
    {
        base.OnEnable();

        // or any other private field
        //_preClickEventProperty = serializedObject.FindProperty("_onPreClick");
        _onClickProperty = serializedObject.FindProperty("m_OnClick");
        _interactableProperty = serializedObject.FindProperty("m_Interactable");
        _disableTillTweenFinProperty = serializedObject.FindProperty("_disableUntilTweenFin");
    }

    public override void OnInspectorGUI()
    {
        //EditorGUILayout.PropertyField(_preClickEventProperty);
        EditorGUILayout.PropertyField(_onClickProperty);
        EditorGUILayout.PropertyField(_interactableProperty);
        EditorGUILayout.PropertyField(_disableTillTweenFinProperty);
        serializedObject.ApplyModifiedProperties();
    }

   
}
