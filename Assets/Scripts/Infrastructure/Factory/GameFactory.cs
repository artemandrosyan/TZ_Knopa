using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

    public InputService CreateHUD()
    {
        GameObject HUD = InstantiateRegistered(AssetPath.HudPath);
        return HUD.GetComponent<InputService>();
    }

    public LoadingScreen CreateLoadingGameCanvas()
    {
        GameObject loadingScreen = InstantiateRegistered(AssetPath.LoadingScreenCanvasPath);
        return loadingScreen.GetComponent<LoadingScreen>();
    }

    public MenuUI CreateMenuCanvas()
    {
        GameObject menuUI = InstantiateRegistered(AssetPath.MenuCanvasPath);
        return menuUI.GetComponent<MenuUI>();
    }

    public HeroMove CreatePlayer()
    {
        GameObject hero = InstantiateRegistered(AssetPath.HeroPath, Vector3.up);
        return hero.GetComponent<HeroMove>();
    }

    private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
    {
        GameObject gameObject = _assets.Instantiate(path: prefabPath, at: at);
        return gameObject;
    }

    private GameObject InstantiateRegistered(string prefabPath)
    {
        GameObject gameObject = _assets.Instantiate(path: prefabPath);
        return gameObject;
    }

}