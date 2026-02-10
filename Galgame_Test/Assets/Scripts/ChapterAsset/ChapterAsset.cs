using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ScenarioLine
{
    public string id;
    public string speaker;
    public string text;

    public string command;
    public string parameter;
}

[CreateAssetMenu(fileName = "NewChapter", menuName = "ChapterAssets")]
public class ChapterAsset
{
    public List<ScenarioLine> scenarioLines = new List<ScenarioLine>();

    public object scriptLines { get; internal set; }
}
