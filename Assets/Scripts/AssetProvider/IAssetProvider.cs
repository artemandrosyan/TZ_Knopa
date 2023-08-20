using UnityEngine;
public interface IAssetProvider
{
    GameObject Instantiate(string path, Vector3 at);
    GameObject Instantiate(string path);
}
