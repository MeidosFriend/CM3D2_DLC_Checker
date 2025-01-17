﻿using System;
using System.IO;

namespace DLC_Checker
{
	public class GameData
	{
        static readonly System.Version VERSION = typeof(Program).Assembly.GetName().Version;
        public static readonly string GAME_NAME = "CM3D2";
        public static readonly string GAME_NAME_LONG = "Custom Maid 3D2";
        public static readonly string INI_FILE = GAME_NAME + "_DLC_Checker.ini";
        public static readonly string DLC_LIST_FILE = "CM_NewListDLC.lst";
        public static readonly string MY_DLC_LIST_FILE = "MY_" + DLC_LIST_FILE;
        public static readonly string GAME_HEADER = "         " + GAME_NAME + "_DLC_Checker Version " + VERSION + "     |   Github.com/MeidosFriend/" + GAME_NAME + "_DLC_Checker"; 
        public static readonly string GAME_REGISTRY = "HKEY_CURRENT_USER\\SOFTWARE\\KISS\\" + "カスタムメイド3D2";
        
        public static string DLC_URL = "https://raw.githubusercontent.com/MeidosFriend/" + GAME_NAME + "_DLC_Checker/master/" + DLC_LIST_FILE;
        public static string DLC_LIST_PATH = Path.Combine(Directory.GetCurrentDirectory(), DLC_LIST_FILE);
        
        public static string UseCurrentDir;
        public static string UpdateListFile;
        public static string MyDLCListFile;
        public static string MyURL;
        public static string UseMyURL;

        public GameData()
		{
            IniFile MyIni = new IniFile();
            //if (!MyIni.KeyExists("UseCurrentDir", "GameDirectory"))
            //{
                //MyIni.Write("UseCurrentDir", "No", "GameDirectory");
            //}
            //UseCurrentDir = MyIni.Read("UseCurrentDir", "GameDirectory").ToUpper();

            if (!MyIni.KeyExists("UpdateListFile", "DLCListFile"))
            {
                MyIni.Write("UpdateListFile", "Yes", "DLCListFile");
            }
            UpdateListFile = MyIni.Read("UpdateListFile", "DLCListFile").ToUpper();

            if (!MyIni.KeyExists("MyDLCListFile", "DLCListFile"))
            {
                MyIni.Write("MyDLCListFile", "No", "DLCListFile");
            }
            MyDLCListFile = MyIni.Read("MyDLCListFile", "DLCListFile").ToUpper();

            if (!MyIni.KeyExists("MyURL", "CustomURL"))
            {
                MyIni.Write("MyURL", DLC_URL, "CustomURL");
            }
            MyURL = MyIni.Read("MyURL", "CustomURL");

            if (!MyIni.KeyExists("UseMyURL", "CustomURL"))
            {
                MyIni.Write("UseMyURL", "No", "CustomURL");
            }
            UseMyURL = MyIni.Read("UseMyURL", "CustomURL").ToUpper();

            if (MyDLCListFile == "YES")
            {
                DLC_LIST_PATH = Path.Combine(Directory.GetCurrentDirectory(), MY_DLC_LIST_FILE);
            }

            if (UseMyURL == "YES")
            {
                DLC_URL = MyURL;
            }

        }
        public string GetUpdateListFile()
        {
            return UpdateListFile;
        }
        public string GetMyDLCListFile()
        {
            return MyDLCListFile;
        }
        public string GetUseCurrentDir()
        {
            return UseCurrentDir;
        }

        public string GetUseMyURL()
        {
            return UseMyURL;
        }

        public string GetMyURL()
        {
            return MyURL;
        }
        public string GetGAME_NAME()
        {
            return GAME_NAME;
        }
        public string GetGAME_NAME_LONG()
        {
            return GAME_NAME_LONG;
        }
        public string GetINI_FILE()
        {
            return INI_FILE;
        }
        public string GetDLC_LIST_FILE()
        {
            return DLC_LIST_FILE;
        }

        public string GetMY_DLC_LIST_FILE()
        {
            return MY_DLC_LIST_FILE;
        }

        public string GetGAME_HEADER()
        {
            return GAME_HEADER;
        }
        public string GetDLC_URL()
        {
            return DLC_URL;
        }
        public string GetGAME_REGISTRY()
        {
            return GAME_REGISTRY;
        }

        public string GetDLC_LIST_PATH()
        {
            return DLC_LIST_PATH;
        }

        


    }
}