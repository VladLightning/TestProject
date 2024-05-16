using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Tables;

public class Localization : MonoBehaviour
{
    public LocalizeStringEvent localizationTarget;
    public TableReference table;
    public TableEntryReference entry;

    private void Start()
    {
        
    }

    public void Localize()
    {
        localizationTarget.StringReference.SetReference(table, entry);
    }
}
