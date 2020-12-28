﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RosSharp.RosBridgeClient.MessageTypes.Nav;
using UnityEngine;
using UnityEngine.UI;

namespace PGM
{
    public class PgmReader : MonoBehaviour
    {
        public Image imageToUpdate;
        
        private Texture2D texture;
        private Color[] mapColorArray;
        private bool setMap;
        private float mapWidth, mapHeight;
        
        private void Awake()
        {
            setMap = false;
            texture = new Texture2D(0, 0);
        }

        private void Update()
        {
            if (setMap)
            {
                setMap = false;
                
                texture.Resize((int)mapWidth, (int)mapHeight);
                texture.Apply();

                texture.SetPixels(mapColorArray);
                texture.Apply();
            
                GetComponent<Renderer>().material.mainTexture = texture;
            
                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            
                if (sprite != null)
                {
                   // imageToUpdate.sprite = sprite;
                }
            }
        }

        public void VisualizeMap(OccupancyGrid message)
        {
            try
          {
              var mapByteArray = message.data;

              mapWidth = message.info.width;
              mapHeight = message.info.height;
        
              mapColorArray = new Color[mapByteArray.Length];
        
              for (var i = 0; i < mapByteArray.Length; i++)
              {
                  Color color;
                  
                  switch (mapByteArray[i])
                  {    
                      default:
                      case -1:
                          continue;
                      case 0:
                          color = new Color((float)0.5,(float)0.5, (float)0.5);
                          break;
                      case 100: 
                          color = new Color(0, 0, 1);
                          break;
                  }
                  mapColorArray[i] = color;
              }
        
              setMap = true;
          }
          catch (Exception e)
          {
              Debug.Log(e.Message);
          }
        }
    }
}