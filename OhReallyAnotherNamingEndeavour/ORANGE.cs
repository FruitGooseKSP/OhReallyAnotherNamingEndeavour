using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

namespace OhReallyAnotherNamingEndeavour
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]

    public class ORANGE : PartModule
    {

        [KSPEvent(active = true, guiActiveEditor = true, guiName = "Change Name")]
        public void SetNewName()
        {
            chosenName = SelectName();
            shipNameBox.text = chosenName;
        }

        public TMPro.TMP_InputField shipNameBox;
        public List<String> firstNames;
        public List<String> secondNames;
        public string pathToData;
        public string pathToFirst;
        public string pathToSecond;
        public string chosenName;

        public void Start() 
        {
            if (HighLogic.LoadedSceneIsEditor)
            {
                shipNameBox = EditorLogic.fetch.shipNameField;
                pathToData = KSPUtil.ApplicationRootPath + "/GameData/FruitKocktail/ORANGE/PluginData/";
                pathToFirst = pathToData + "first.txt";
                pathToSecond = pathToData + "second.txt";
                firstNames = new List<String>(File.ReadAllLines(pathToFirst));
                secondNames = new List<String>(File.ReadAllLines(pathToSecond));
            }
        }

        private String SelectName() 
        {
            System.Random random = new System.Random();
            int firstNameIndex = random.Next(firstNames.Count);
            int secondNameIndex = random.Next(secondNames.Count);
            string firstName = firstNames[firstNameIndex];
            string secondName = secondNames[secondNameIndex];
            string fullName = firstName + " " + secondName;
            return fullName;
        }

    }
}
