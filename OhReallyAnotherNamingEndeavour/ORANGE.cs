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

            if (chosenName != null)
            {
                shipNameBox.text = chosenName;
            }
            else
            {
                Debug.LogError("ORANGE: unable to select a name!");
            }
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

            try
            {
                int firstCount = firstNames.Count();
                int secondCount = secondNames.Count();

                if (firstCount == 0 && secondCount == 0)
                {
                    Debug.LogError("ORANGE: lists are empty!");
                    return null;
                }
                else if (firstCount == 0 && secondCount != 0)
                {
                    return SelectionFromSingle(2);
                }
                else if (firstCount != 0 && secondCount == 0)
                {
                    return SelectionFromSingle(1);
                }

                else
                {
                    return SelectionFromAll();
                }

            }
            catch
            {
                Debug.LogError("ORANGE: Cannot read from lists, please ensure they exist!");
                return null;
            }



            


            
        }

        private string SelectionFromSingle(int type)
        {
            System.Random random = new System.Random();

            if (type == 1)
            {
                int firstNameIndex = random.Next(firstNames.Count);
                string firstName = firstNames[firstNameIndex];
                return firstName;
            }
            else if (type == 2)
            {
                int secondNameIndex = random.Next(secondNames.Count);
                string secondName = secondNames[secondNameIndex];
                return secondName;
            }

            else return null;
        }

        private string SelectionFromAll()
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
