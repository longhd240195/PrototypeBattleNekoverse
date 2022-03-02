using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityCommon;
using UnityEditor;
using UnityEngine;
using UnityGoogleDrive;

public class TestLoadGoogleDrive : MonoBehaviour
{
    private GoogleDriveFiles.ListRequest request;
    private string filePath = string.Empty;
    private string result = string.Empty;

    [SerializeField] private TextMeshProUGUI tmp;
    
    public void LoadFile()
    {
        StartCoroutine(LoadAlotFile());
    }

    public IEnumerator LoadAlotFile()
    {
        var paths = new[] {"ModelFbx/Fire/arms/101.fbx", "ModelFbx/Fire/arms/102.fbx", "ModelFbx/Fire/arms/103.fbx"};
        foreach (var b in paths)
        {
            yield return GetFileByPathRoutine(b);
        }
    }

    private IEnumerator GetFileByPathRoutine (string filePath)
    {
        // A folder in Google Drive is actually a file with the MIME type 'application/vnd.google-apps.folder'. 
        // Hierarchy relationship is implemented via File's 'Parents' property. To get the actual file using it's path 
        // we have to find ID of the file's parent folder, and for this we need IDs of all the folders in the chain. 
        // Thus, we need to traverse the entire hierarchy chain using List requests. 
        // More info about the Google Drive folders: https://developers.google.com/drive/v3/web/folder.

        var fileName = filePath.Contains("/") ? filePath.GetAfter("/") : filePath;
        var parentNames = filePath.Contains("/") ? filePath.GetBeforeLast("/").Split('/') : null;

        // Resolving folder IDs one by one to find ID of the file's parent folder.
        var parendId = "root"; // 'root' is alias ID for the root folder in Google Drive.
        if (parentNames != null)
        {
            for (int i = 0; i < parentNames.Length; i++)
            {
                request = new GoogleDriveFiles.ListRequest();
                request.Fields = new List<string> { "files(id)" };
                request.Q = $"'{parendId}' in parents and name = '{parentNames[i]}' and mimeType = 'application/vnd.google-apps.folder' and trashed = false";

                yield return request.Send();

                if (request.IsError || request.ResponseData.Files == null || request.ResponseData.Files.Count == 0)
                {
                    result = $"Failed to retrieve '{parentNames[i]}' part of '{filePath}' file path.";
                    yield break;
                }

                if (request.ResponseData.Files.Count > 1)
                    Debug.LogWarning($"Multiple '{parentNames[i]}' folders been found.");

                parendId = request.ResponseData.Files[0].Id;
            }
        }

        // Searching the file.
        request = new GoogleDriveFiles.ListRequest();
        request.Fields = new List<string> { "files(id, size, modifiedTime)" };
        request.Q = $"'{parendId}' in parents and name = '{fileName}'";

        yield return request.Send();

        if (request.IsError || request.ResponseData.Files == null || request.ResponseData.Files.Count == 0)
        {
            result += $"\nFailed to retrieve '{filePath}' file.";
            yield break;
        }

        if (request.ResponseData.Files.Count > 1)
            Debug.LogWarning($"Multiple '{filePath}' files been found.");

        var file = request.ResponseData.Files[0];
        result = string.Format("\nID: {0} Size: {1:0.00}MB Modified: {2:dd.MM.yyyy HH:MM:ss}",
            file.OriginalFilename, file.Size * .000001f, file.CreatedTime);
        Log(result);
    }

    private void Check(Object o)
    {
        var go = o as GameObject;
        Debug.Log(go.name);
    }

    private void Log(string n)
    {
        tmp.text += "\n" + n;
    }
}