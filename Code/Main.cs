using ButterBox;
using System;
using NeoModLoader.api;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using NCMS;
using NCMS.Utils;
using ModDeclaration;
using UnityEngine;
using ReflectionUtility;
using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Config;
using System.Reflection;
using UnityEngine.Tilemaps;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ButterBox
{
    [ModEntry]
    public class Main : MonoBehaviour, IMod, IReloadable
    {
        public static GameObject backgroundAvatar;
        public static ModDeclare mod_declare;
        public static GameObject gameObject;

        public ModDeclare GetDeclaration()
        {
            return mod_declare;
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public string GetUrl()
        {
            return "https://github.com/WorldBoxOpenMods";
        }

        public void OnLoad(ModDeclare pModDecl, GameObject pGameObject)
        {
            mod_declare = pModDecl;
            gameObject = pGameObject;
            Config.isEditor = true;

            Mod.Info = typeof(Info)
                       .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[]
                                       {
                                           typeof(NCMod)
                                       },
                                       null)
                       ?.Invoke(new object[]
                       {
                           new NCMod
                           {
                               name = pModDecl.Name,
                               author = pModDecl.Author,
                               description = pModDecl.Description,
                               path = pModDecl.FolderPath,
                               version = pModDecl.Version,
                               iconPath = pModDecl.IconPath,
                               targetGameBuild = pModDecl.TargetGameBuild
                           }
                       }) as Info;

        }

        public void Reload()
        {
            
        }
        
    }
       
}