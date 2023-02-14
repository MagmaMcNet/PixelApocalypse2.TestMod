using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using MagmaMc.Modding;

namespace Mod.MagmaMc.ExampleMod
{
    public class Mod: IMod
    {
        public string Name { get; set; } = "ExampleMod";
        public string Description { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
        public string CurrentScene { get; set; }

        public ushort x = 1;
        public ushort y = 1;
        public ushort z = 1;

        [InitializeMethod]
        public void OnLoad() => Debug.Log("Menu UI Test Mod Loaded By MagmaMc");

        [InitializeMethod]
        public void CreateUI()
        {
            try
            {

                // Create a canvas game object.
                GameObject canvas = new GameObject("Canvas");
                canvas.AddComponent<Canvas>();
                canvas.AddComponent<CanvasScaler>();
                canvas.AddComponent<GraphicRaycaster>();

                // Create a button game object.
                GameObject button = new GameObject("Button");
                button.transform.SetParent(canvas.transform);

                // Add a RectTransform component to the button.
                RectTransform rectTransform = button.AddComponent<RectTransform>();
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.sizeDelta = new Vector2(200, 50);

                // Add a Button component to the button.
                Button buttonComponent = button.AddComponent<Button>();

                // Create a text game object.
                GameObject text = new GameObject("Text");
                text.transform.SetParent(button.transform);

                // Add a RectTransform component to the text.
                RectTransform textRectTransform = text.AddComponent<RectTransform>();
                textRectTransform.anchoredPosition = Vector2.zero;
                textRectTransform.sizeDelta = new Vector2(200, 50);

                // Add a Text component to the text.
                Text textComponent = text.AddComponent<Text>();
                textComponent.text = "Click Me";
                textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                textComponent.alignment = TextAnchor.MiddleCenter;

                // Set the text as the child of the button's Text component.
                buttonComponent.GetComponentInChildren<Text>().text = textComponent.text;
            } catch(Exception ex) { Debug.LogException(ex); }
        }
    }
}