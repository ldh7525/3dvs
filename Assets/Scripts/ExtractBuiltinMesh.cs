#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class ExtractBuiltinMesh
{
    [MenuItem("Tools/Extract Capsule Mesh")]
    public static void Extract()
    {
        // 기본 캡슐 생성 후 메쉬 복제
        GameObject tempCapsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Mesh meshCopy = Object.Instantiate(tempCapsule.GetComponent<MeshFilter>().sharedMesh);
        GameObject.DestroyImmediate(tempCapsule);

        // Project 창에 실제 에셋 파일로 저장
        AssetDatabase.CreateAsset(meshCopy, "Assets/Extracted_Capsule.asset");
        AssetDatabase.SaveAssets();
        Debug.Log("Assets 폴더에 Capsule 메쉬 에셋이 추출되었습니다.");
    }
}
#endif