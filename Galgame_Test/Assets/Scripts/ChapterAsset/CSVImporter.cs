using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CSVImporter : EditorWindow
{
    [MenuItem("Tools/Convert CSV to Chapter")]
    public static void ConvertCSV()
    {
        TextAsset csvFile = Resources.Load<TextAsset>("ChapterSCV/Chapter1");
        if(csvFile == null)
        {
            Debug.LogError("[CSVImporter]:找不到CSV文件!");
            return;
        }

        ChapterAsset asset = ScriptableObject.CreateInstance<ChapterAsset>();

        string[] fileLines = csvFile.text.Split('\n');

        for(int i = 0; i < fileLines.Length; i++)
        {
            string line = fileLines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;//跳过空行

            string[] columns = line.Split(',');

            if(columns.Length < 5) continue;

            ScenarioLine scriptRow = new ScenarioLine();
            scriptRow.id = columns[0].Trim();
            scriptRow.speaker = columns[1].Trim();
            scriptRow.text = columns[2].Trim();      // 这里可能会因为台词里有逗号被截断，先不管
            scriptRow.command = columns[3].Trim();
            scriptRow.parameter = columns[4].Trim();

            asset.scriptLines.Add(scriptRow);
        }

        string path = "Assets/Resources/Chapter1_Data.asset";
        AssetDatabase.CreateAsset(asset, path);
        AssetDatabase.SaveAssets();

        Debug.Log($"成功生成剧本文件：{path}");
    }
}
