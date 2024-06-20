// using UnityEngine;
// using UnityEditor;
// using System.Collections.Generic;
//
// public class EditorStateManager : EditorWindow
// {
//     private List<string> _states;
//     private int _selectedStateIndex;
//     private List<string> _stateHierarchy;
//
//     [MenuItem("Window/State Manager")]
//     public static void ShowWindow()
//     {
//         GetWindow<EditorStateManager>("State Manager");
//     }
//
//     private void OnEnable()
//     {
//         _states = new List<string>();
//         _selectedStateIndex = -1;
//     }
//
//     private void OnGUI()
//     {
//         GUILayout.Label("State Manager", EditorStyles.boldLabel);
//
//         // Show list of states
//         GUILayout.Label("States:");
//         if (_states.Count > 0)
//         {
//             _selectedStateIndex = GUILayout.SelectionGrid(_selectedStateIndex, _states.ToArray(), 1);
//         }
//         else
//         {
//             GUILayout.Label("No states.");
//             _selectedStateIndex = -1;
//         }
//
//         // Add state button
//         if (GUILayout.Button("Add State"))
//         {
//             _states.Add("New State " + (_states.Count + 1));
//             _stateHierarchy.Add("");
//             _selectedStateIndex = _states.Count - 1;
//         }
//
//         // Remove state button
//         if (_selectedStateIndex != -1 && GUILayout.Button("Remove State"))
//         {
//             _states.RemoveAt(_selectedStateIndex);
//             _stateHierarchy.RemoveAt(_selectedStateIndex);
//             _selectedStateIndex = _states.Count > 0 ? 0 : -1;
//         }
//
//         // Rename state field
//         if (_selectedStateIndex != -1)
//         {
//             GUILayout.BeginHorizontal();
//             GUILayout.Label("Rename state:");
//             _states[_selectedStateIndex] = GUILayout.TextField(_states[_selectedStateIndex]);
//             GUILayout.EndHorizontal();
//         }
//
//         // Show hierarchy of states
//         GUILayout.Label("State hierarchy:");
//         if (_stateHierarchy.Count > 0)
//         {
//             for (int i = 0; i < _stateHierarchy.Count; i++)
//             {
//                 GUILayout.Label(_stateHierarchy[i]);
//             }
//         }
//         else
//         {
//             GUILayout.Label("No states.");
//         }
//
//         void OnEnable()
//         {
//             _states = new List<string>();
//             _stateHierarchy = new List<string>();
//             _selectedStateIndex = -1;
//         }
//     }
// }