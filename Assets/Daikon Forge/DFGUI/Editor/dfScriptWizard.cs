/* Copyright 2013 Daikon Forge */
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class dfScriptWizard : EditorWindow
{
    private static Dictionary<string, string> typeMap = new Dictionary<string, string>()
    {
        { "System.Boolean", "bool" },
        { "System.Byte", "byte" },
        { "System.SByte", "sbyte" },
        { "System.Char", "char" },
        { "System.Decimal", "decimal" },
        { "System.Double", "double" },
        { "System.Single", "float" },
        { "System.Int32", "int" },
        { "System.UInt32", "uint" },
        { "System.Int64", "long" },
        { "System.UInt64", "ulong" },
        { "System.Object", "object" },
        { "System.Int16", "short" },
        { "System.UInt16", "ushort" },
        { "System.String", "string" }
    };

    private const int BUTTON_WIDTH = 120;
    private const int LABEL_WIDTH = 125;

    private dfControl target;
    private List<EventInfo> events = new List<EventInfo>();
    private List<string> expandedSections = new List<string>() { "Mouse Input" };
    private List<ComponentReference> referencedComponents = new List<ComponentReference>();

    private Vector2 previewScrollPos;
    private Vector2 eventsScrollPos;
    private string className = "EXAMPLE";
    private bool referenceControl = false;

    #region Static methods 

    public static void CreateScript(dfControl control)
    {
        if (control == null)
            return;

        if (string.IsNullOrEmpty(EditorApplication.currentScene))
        {
            EditorUtility.DisplayDialog("Please save your scene", "Please save your scene before using the Script Wizard", "OK");
            return;
        }

        var events = control
            .GetType()
            .GetAllFields()
            .Where(x => typeof(Delegate).IsAssignableFrom(x.FieldType))
            .Select(x => new EventInfo(x))
            .OrderBy(x => x.Category + "." + x.Field.Name)
            .ToList();

        var path = buildGameObjectPath(control);

        var dialog = GetWindow<dfScriptWizard>(true, "Create Script - " + path);
        dialog.target = control;
        dialog.events = events;
        dialog.minSize = new Vector2(640, 480);
        dialog.className = control.name.Replace(" ", "") + "Events";
    }

    private static string buildGameObjectPath(dfControl control)
    {
        var obj = control.transform;
        var buffer = new StringBuilder();

        while (obj != null)
        {
            if (buffer.Length > 0)
                buffer.Insert(0, "/");
            buffer.Insert(0, obj.name);
            obj = obj.parent;
        }

        buffer.Append(" (");
        buffer.Append(control.GetType().Name);
        buffer.Append(")");

        return buffer.ToString();
    }

    #endregion

    public void OnGUI()
    {
        dfEditorUtil.LabelWidth = LABEL_WIDTH;

        EditorGUILayout.BeginHorizontal();
        {
            GUILayout.Space(10);
            showPreview();
            GUILayout.Space(10);

            EditorGUILayout.BeginVertical();
            {
                showOptions();
                showDocumentationLink();
                GUILayout.Space(10);
                showButtons();
            }
            EditorGUILayout.EndVertical();

            GUILayout.Space(10);
        }
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);
    }

    private void showDocumentationLink()
    {
        if (GUILayout.Button("View online API documentation", "minibutton", GUILayout.ExpandWidth(true)))
        {
            Application.OpenURL("http://www.daikonforge.com/docs/df-gui/index.html");
        }
    }

    private void showButtons()
    {
        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Cancel", GUILayout.Width(BUTTON_WIDTH)))
            {
                Close();
                GUIUtility.ExitGUI();
            }

            bool guiEnabledTemp = GUI.enabled;
            if (GUILayout.Button("Create", GUILayout.Width(BUTTON_WIDTH)))
            {
                saveAndAttachScript();
            }
            GUI.enabled = guiEnabledTemp;
        }
        GUILayout.EndHorizontal();
    }

    private void saveAndAttachScript()
    {
        var scenePath = Path.GetDirectoryName(EditorApplication.currentScene).Replace("\\", "/");
        var path = EditorUtility.SaveFilePanel("Create Script", scenePath, className, "cs");
        if (string.IsNullOrEmpty(path))
            return;

        var filename = Path.GetFileNameWithoutExtension(path);
        if (!Regex.IsMatch(filename, "^[a-zA-Z$_]+[a-zA-Z0-9$_]*$"))
        {
            EditorUtility.DisplayDialog("Invalid file name", "You have chosen a file name that cannot be used as a valid identifier for a MonoBehavior", "CANCEL");
            return;
        }

        using (var file = File.CreateText(path))
        {
            className = filename;
            file.WriteLine(generateScript());
        }

        AssetDatabase.Refresh();
        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceSynchronousImport);

        var gameObj = target.gameObject;
        var script = AssetDatabase.LoadAssetAtPath(path, typeof(MonoScript)) as MonoScript;

        if (script != null)
        {
            var scriptClass = script.GetClass();
            if (scriptClass != null)
            {
                Undo.AddComponent(gameObj, scriptClass);
            }
        }

        #region Delayed execution

        // Declared with null value to eliminate "uninitialized variable"
        // compiler error in lambda below.
        EditorApplication.CallbackFunction callback = null;

        callback = () =>
        {
            AssetDatabase.OpenAsset(script);
            EditorApplication.delayCall -= callback;
        };

        EditorApplication.delayCall += callback;

        #endregion

        Close();
        GUIUtility.ExitGUI();
    }

    private void showOptions()
    {
        className = EditorGUILayout.TextField("Class Name", className);
        referenceControl = EditorGUILayout.Toggle("Reference Control", referenceControl);

        // EditComponentReferences();

        using (dfEditorUtil.BeginGroup("Events"))
        {
            var categories = events.Select(x => x.Category).Distinct().ToList();

            EditorGUILayout.BeginVertical("TextField", GUILayout.ExpandWidth(true));
            {
                eventsScrollPos = EditorGUILayout.BeginScrollView(eventsScrollPos);
                {
                    for (int i = 0; i < categories.Count; i++)
                    {
                        var category = categories[i];
                        if (categoryHeader(category))
                        {
                            var categoryEvents = events.Where(x => x.Category == category).ToList();
                            for (int x = 0; x < categoryEvents.Count; x++)
                            {
                                var evt = categoryEvents[x];

                                Rect toggleRect = GUILayoutUtility.GetRect(GUIContent.none, EditorStyles.toggle);
                                toggleRect.x += 15;
                                toggleRect.width -= 15;

                                evt.IsSelected = GUI.Toggle(toggleRect, evt.IsSelected, evt.Field.Name);
                            }
                        }
                    }
                }
                EditorGUILayout.EndScrollView();
            }
            EditorGUILayout.EndVertical();
        }
    }

    private void EditComponentReferences()
    {
        using (dfEditorUtil.BeginGroup("References"))
        {
            if (referencedComponents.Count > 0)
            {
                var collectionChanged = false;
                for (int i = 0; i < referencedComponents.Count && !collectionChanged; i++)
                {
                    var component = referencedComponents[i];
                    var header = !string.IsNullOrEmpty(component.Name) ? component.Name : "Item " + (i + 1);
                    GUILayout.Label(header);
                    EditorGUI.indentLevel += 1;

                    var savedColor = GUI.color;
                    if (referencedComponents.Count(x => x.Name == component.Name) > 1)
                        GUI.color = EditorGUIUtility.isProSkin ? Color.yellow : Color.red;

                    component.Name = EditorGUILayout.TextField("Name", component.Name);
                    GUI.color = savedColor;

                    EditorGUILayout.BeginHorizontal();
                    {
                        EditorGUILayout.LabelField("Component", "", GUILayout.Width(LABEL_WIDTH - 14));
                        GUILayout.Space(2);
                        component.Component = (Component)EditorGUILayout.ObjectField(component.Component, typeof(Component), true);

                        if (GUILayout.Button("X", GUILayout.Width(22)))
                        {
                            referencedComponents.RemoveAt(i);
                            collectionChanged = true;
                        }
                    }
                    EditorGUILayout.EndHorizontal();

                    EditorGUI.indentLevel -= 1;
                }
            }

            EditorGUILayout.HelpBox("Drop a component here to add a component reference", MessageType.Info);
            var evt = Event.current;
            if (evt != null)
            {
                Rect textRect = GUILayoutUtility.GetLastRect();
                if (evt.type == EventType.DragUpdated || evt.type == EventType.DragPerform)
                {
                    if (textRect.Contains(evt.mousePosition))
                    {
                        var dragged = DragAndDrop.objectReferences;
                        DragAndDrop.visualMode = (dragged.Length > 0) ? DragAndDropVisualMode.Copy : DragAndDropVisualMode.None;
                        if (evt.type == EventType.DragPerform)
                        {
                            for (int i = 0; i < dragged.Length; i++)
                            {
                                Component component = null;
                                if (dragged[i] is Component)
                                {
                                    component = dragged[i] as Component;
                                }
                                else
                                {
                                    var go = dragged[i] as GameObject;
                                    if (go != null)
                                    {
                                        component = go.GetComponent<Component>();
                                    }
                                }

                                if (component != null)
                                {
                                    referencedComponents.Add(new ComponentReference { Component = component });
                                }
                            }

                            evt.Use();
                        }
                    }
                }
            }

            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Add", GUILayout.Width(BUTTON_WIDTH)))
                {
                    referencedComponents.Add(new ComponentReference());
                }
            }
            GUILayout.EndHorizontal();
        }
    }

    private bool categoryHeader(string category)
    {
        var enabled = expandedSections.Contains(category);
        var newEnabled = EditorGUILayout.Foldout(enabled, category, true);
        if (newEnabled != enabled)
        {
            if (newEnabled)
                expandedSections.Add(category);
            else
                expandedSections.Remove(category);
        }

        return newEnabled;
    }

    private void showPreview()
    {
        var previewContent = new GUIContent();
        previewContent.text = "Preview";
        EditorGUILayout.BeginVertical("TextField", GUILayout.ExpandWidth(true));
        {
            previewScrollPos = EditorGUILayout.BeginScrollView(previewScrollPos);
            {
                GUILayout.Label(generateScript(), "TextArea");
            }
            EditorGUILayout.EndScrollView();
        }
        EditorGUILayout.EndVertical();
    }

    private string generateScript()
    {
        var script = new StringBuilder();
        script.AppendLine("using UnityEngine;");
        script.AppendLine("using System.Collections;");
        script.AppendLine();
        script.AppendLine("public class " + className + " : MonoBehaviour");
        script.AppendLine("{");

        foreach (var evt in events.Where(x => x.IsSelected))
        {
            script.AppendLine("    public " + evt.DelegateType + " " + evt.Field.Name + ";");
        }

        script.AppendLine();
        script.AppendLine("    void Start()");
        script.AppendLine("    {");
        script.AppendLine("        // Initialization code here");
        script.AppendLine("    }");
        script.AppendLine();
        script.AppendLine("    void Update()");
        script.AppendLine("    {");
        script.AppendLine("        // Update code here");
        script.AppendLine("    }");
        script.AppendLine();
        script.AppendLine("}");
        return script.ToString();
    }
}

public class EventInfo
{
    public FieldInfo Field { get; private set; }
    public string Category { get; private set; }
    public bool IsSelected { get; set; }
    public string DelegateType { get; private set; }

    public EventInfo(FieldInfo field)
    {
        Field = field;
        DelegateType = field.FieldType.Name;
        Category = field.DeclaringType.Name;
        IsSelected = true;
    }
}

public class ComponentReference
{
    public string Name { get; set; }
    public Component Component { get; set; }
}
