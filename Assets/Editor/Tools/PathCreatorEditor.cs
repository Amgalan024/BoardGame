using System;
using UnityEditor;
using UnityEngine;
using Views;

namespace Editor.Tools
{
    [CustomEditor(typeof(PathCreator))]
    public class PathCreatorEditor : UnityEditor.Editor
    {
        private bool _editingEnabled = false;

        private SerializedProperty _pathPointPrefab;
        private SerializedProperty _parent;

        private void OnSceneGUI()
        {
            if (_editingEnabled)
            {
                if (Event.current.type == EventType.MouseDown)
                {
                    Ray worldRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                    RaycastHit hitInfo;

                    if (Physics.Raycast(worldRay, out hitInfo))
                    {
                        if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Map"))
                        {
                            var position = hitInfo.point;

                            var pathPoint = Instantiate((PathPointView) _pathPointPrefab.objectReferenceValue, position,
                                Quaternion.identity);

                            pathPoint.transform.SetParent((Transform) _parent.objectReferenceValue);

                            EditorUtility.SetDirty(pathPoint);
                        }
                    }
                }
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            _pathPointPrefab = serializedObject.FindProperty(nameof(_pathPointPrefab));
            _parent = serializedObject.FindProperty(nameof(_parent));

            EditorGUILayout.PropertyField(_pathPointPrefab);
            EditorGUILayout.PropertyField(_parent);

            if (_editingEnabled)
            {
                if (GUILayout.Button("Disable Editing"))
                {
                    _editingEnabled = false;
                }
            }
            else
            {
                if (GUILayout.Button("Enable Editing"))
                {
                    _editingEnabled = true;
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}