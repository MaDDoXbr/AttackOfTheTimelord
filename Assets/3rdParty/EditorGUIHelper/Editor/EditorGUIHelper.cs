using UnityEditor;
using UnityEngine;

// namespace Paalo.Utils
// {
	/// <summary>
	/// Contains helper methods for common (and tedious) operations when writing IMGUI-code.
	/// </summary>
	public static class EditorGUIHelper
	{
		private static readonly float originalLabelWidth = EditorGUIUtility.labelWidth;
		private static readonly int originalIndentation = EditorGUI.indentLevel;

		/// <summary>
		/// A GUIStyle made of a box which is shaped like line.
		/// </summary>
		/// <returns></returns>
		public static GUIStyle GetSeparatorMarginStyle()
		{
			var separatorMarginStyle = new GUIStyle(GUI.skin.box) { margin = new RectOffset(0, 0, 10, 10) };
			return separatorMarginStyle;
		}

		/// <summary>
		/// Draws a box/rect which looks like a separation line. Useful for sectioning off different parts of your GUI.
		/// <para></para>
		/// Expands its width by default to match the width of the GUI/Editor Window.
		/// </summary>
		public static void MakeSeparatorLine(bool expandWidth = true)
		{
			var separatorMarginStyle = GetSeparatorMarginStyle();
			GUILayout.Box("", separatorMarginStyle, GUILayout.Height(1f), GUILayout.ExpandWidth(expandWidth));
		}

		public static void IncrementIndentation()
		{
			EditorGUI.indentLevel++;
		}
		public static void DecrementIndentation()
		{
			EditorGUI.indentLevel--;
		}

		public static void SetIndentation(int desiredIndent)
		{
			EditorGUI.indentLevel = desiredIndent;
		}

		public static void ResetIndentation()
		{
			EditorGUI.indentLevel = originalIndentation;
		}

		/// <summary>
		/// Useful for making a Bool Toggle (<see cref="EditorGUILayout.Toggle(bool, GUILayoutOption[])"/>) have its checkbox at the far right of an editor window. 
		/// </summary>
		/// <param name="containingBoxForLabel"></param>
		/// <param name="offsetFromRightEdge"></param>
		public static void SetWideLabelWidth(Rect containingBoxForLabel, float offsetFromRightEdge = 30f)
		{
			//Make all the longer folder paths visible, as well as make all checkboxes align along the right side of the box.
			var checkBoxPadding = offsetFromRightEdge;
			var alignedCheckBoxesLabelWidth = containingBoxForLabel.width - checkBoxPadding;
			EditorGUIUtility.labelWidth = alignedCheckBoxesLabelWidth;
		}

		/// <summary>
		/// Reset the <see cref="EditorGUIUtility.labelWidth"/> to the default value.
		/// </summary>
		public static void ResetLabelWidth()
		{
			EditorGUIUtility.labelWidth = originalLabelWidth;
		}

		/// <summary>
		/// Useful for setting the <see cref="EditorGUIUtility.labelWidth"/> to the width of your desired label.
		/// </summary>
		/// <param name="label"></param>
		/// <returns></returns>
		public static float CalculateLabelWidth(GUIContent label, float padding = 0f)
		{
			float labelWidth = GUI.skin.label.CalcSize(label).x + padding;
			return labelWidth;
		}

		/// <summary>
		/// Useful for setting the <see cref="EditorGUIUtility.labelWidth"/> to the width of your desired label.
		/// </summary>
		/// <param name="label"></param>
		/// <returns></returns>
		public static float CalculateLabelWidth(string label, float padding = 0f)
		{
			return CalculateLabelWidth(new GUIContent(label), padding);
		}
	}
// }
