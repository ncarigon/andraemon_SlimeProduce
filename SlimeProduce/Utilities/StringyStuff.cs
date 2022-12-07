﻿using Microsoft.Xna.Framework;
using StardewValley.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeProduce
{
    public static class StringyStuff
    {
        public static string ToSlimeString(GreenSlime slime)
            => $"{slime.color.Value.PackedValue}/{slime.Name == "Tiger Slime"}/{slime.firstGeneration.Value}/{slime.specialNumber.Value}";

        public static bool TryParseSlimeString(string slimeData, out Color color, out bool isTiger, out bool firstGeneration, out int specialNumber)
        {
            color = Color.White;
            isTiger = false;
            firstGeneration = false;
            specialNumber = 0;

            string[] data;

            if (slimeData == null || (data = slimeData.Split('/')).Length != 4)
                return false;
            
            if (uint.TryParse(data[0], out uint packed)) color = new Color(packed);
            else return false;

            if (!bool.TryParse(data[1], out isTiger)) return false;

            if (!bool.TryParse(data[2], out firstGeneration)) return false;

            if (!int.TryParse(data[3], out specialNumber)) return false;

            return true;
        }

        public static bool TryGetSlimeColor(string slimeData, out Color color)
        {
            color = Color.White;
            string[] data;

            if (slimeData == null || (data = slimeData.Split('/')).Length != 4)
                return false;

            if (uint.TryParse(data[0], out uint packed))
            {
                color = new Color(packed);
                return true;
            }

            return false;
        }
    }
}