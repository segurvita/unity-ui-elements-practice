using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CustomEditor(typeof(AAA))]
public class TestWindow : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = new VisualElement();

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/TestWindow/TestWindow.uxml");
        VisualElement labelFromUXML = visualTree.CloneTree();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/TestWindow/TestWindow.uss");
        VisualElement labelWithStyle = new Label("Hello World! With Style");
        labelWithStyle.styleSheets.Add(styleSheet);
        root.Add(labelWithStyle);

        return root;
    }
}