using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IGameFactory
{
    MenuUI CreateMenuCanvas();
    LoadingScreen CreateLoadingGameCanvas();
    InputService CreateHUD();
    HeroMove CreatePlayer();
}