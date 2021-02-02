﻿using Assets.Scripts.Unity;
using MelonLoader;
using Assets.Scripts.Utils;
using BloonsTD6_Mod_Helper.Extensions;
using UnityEngine;

namespace FasterForward
{
    public class Main : MelonMod
    {
        public static int speed = 3;
        
        public override void OnUpdate()
        {
            int lastSpeed = speed;
            if (Input.GetKeyDown(KeyCode.F1))
            {
                speed = 3;
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                speed = 5;
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                speed = 10;
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                speed = 25;
            }

            if (speed != lastSpeed)
            {
                Game.instance.ShowMessage("Fast Forward Speed is now " + speed + "x" + (speed == 3 ? " (Default)" : ""), 1f);
            }

            if (TimeManager.FastForwardActive)
            {
                TimeManager.timeScaleWithoutNetwork = speed;
                TimeManager.networkScale = speed;
            }
            else
            {
                TimeManager.timeScaleWithoutNetwork = 1;
                TimeManager.networkScale = 1;
            }
            TimeManager.maxSimulationStepsPerUpdate = speed;
        }

    }

}