using System;
using System.Collections;
using System.Collections.Generic;
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
        private void Awake()
        {
          //  Texture2D texture = new Texture2D((int) message.info.width, (int) message.info.height);
          texture = new Texture2D(384, 384);
          setMap = false;
        }

        private void Update()
        {
            if (setMap)
            {
                setMap = false;
                
              texture.SetPixels(mapColorArray);
                texture.Apply();

                GetComponent<Renderer>().material.mainTexture = texture;

                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

                if (sprite != null)
                {
                    imageToUpdate.sprite = sprite;
                }
            }
        }

        public void VisualizeMap(OccupancyGrid message)
        {
           //  string InputFileName = "map.pgm"; //args[0]
           //
           // PGM picture = new PGM(InputFileName);
           // Debug.Log(picture.GetPgmBytes().Length);
    

          //  var pgmInfo = picture.PrintPGMInfo();
          try
          {
              var mapByteArray = message.data;

              mapColorArray = new Color[mapByteArray.Length];
// Debug.Log(mapByteArray.Length);

              for (var i = 0; i < mapByteArray.Length; i++)
              {
                  // Debug.Log(mapByteArray[i]);
                  Color color;
                  
                  switch (mapByteArray[i])
                  {    
                      case -1:
                          color = new Color(1, 1,1);
                          break;
                      default:
                      case 0:
                          color = new Color(1, 0, 0);
                          break;
                      case 100: 
                          color = new Color(0, 0, 1);
                          break;
                  }
                  // Debug.Log(color);
                 // var color = new Color((float) mapByteArray[i] / 100, (float) mapByteArray[i] / 100,
                //      (float) mapByteArray[i] / 100);
                  mapColorArray[i] = color;
              }

              setMap = true;
          }
          catch (Exception e)
          {
              Debug.Log(e.Message);
          }

        }
        
        // public void VisualizeMap()
        // {
        //     string InputFileName = "map.pgm"; //args[0]
        //
        //     PGM picture = new PGM(InputFileName);
        //     var pgmInfo = picture.PrintPGMInfo();
        //
        //     var mapByteArray = picture.GetPgmBytes();
        //     var mapColorArray = new Color[mapByteArray.Length];
        //
        //     Texture2D texture = new Texture2D(int.Parse(pgmInfo[3]), int.Parse(pgmInfo[4]));
        //    
        //     for(var i = 0; i < mapByteArray.Length; i++)
        //     {
        //         var color = new Color((float)mapByteArray[i]/255, (float)mapByteArray[i]/255, (float)mapByteArray[i]/255 );
        //         mapColorArray[i] = color;
        //     }
        //
        //     texture.SetPixels(mapColorArray);
        //     texture.Apply();
        //
        //     GetComponent<Renderer>().material.mainTexture = texture;
        //    
        //     var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        //
        //     if (sprite != null)
        //     {
        //         imageToUpdate.sprite = sprite;
        //     }
        // }
    }
}