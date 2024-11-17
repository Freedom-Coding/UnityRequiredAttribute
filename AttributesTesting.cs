using UnityEngine;

public class AttributesTesting : MonoBehaviour
{
    [SerializeField][Required] private GameObject testingVariable1;
    [SerializeField][Required] private GameObject testingVariable2;
    [SerializeField][Required] private GameObject testingVariable3;
    [SerializeField][Required] private GameObject testingVariable4;
    [SerializeField][Required(WarningType.InspectorWarning)] private GameObject testingVariable5;
    [SerializeField][Required] private GameObject testingVariable6;
    [SerializeField][Required] private GameObject testingVariable7;
    [SerializeField][Required] private GameObject testingVariable8;
    [SerializeField][Required] private GameObject testingVariable9;
    [SerializeField][Required] private GameObject testingVariable10;
}