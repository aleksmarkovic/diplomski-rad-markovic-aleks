using System;
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
        private List<Color> mapColorList;
        private bool setMap;
        private int blankCounter = 0;
        private void Awake()
        {
          //  Texture2D texture = new Texture2D((int) message.info.width, (int) message.info.height);
          setMap = false;
          texture = new Texture2D(384, 384);
            mapColorList = new List<Color>();
        }

        private void Update()
        {
            if (setMap)
            {
                setMap = false;
                // Debug.Log(blankCounter);
               // var size = Mathf.Sqrt((mapColorArray.Length) - blankCounter);
               // Debug.Log(size); 
               // texture.Resize((int)size, (int)size);
               //
              //  texture.Apply();


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
            try
          {
              var mapByteArray = message.data;

              for (var i = 0; i < mapByteArray.Length; i++)
              {
                  if (mapByteArray[i] == -1)
                      blankCounter++;
              } //todo
              
              mapColorArray = new Color[mapByteArray.Length];

              for (var i = 0; i < mapByteArray.Length; i++)
              {
                  Color color;
                  
                  switch (mapByteArray[i])
                  {    
                      case -1:
                          color = new Color(1, 1,1);
                          blankCounter++;
                          continue;
                          break;
                      default:
                      case 0:
                          color = new Color(1, 0, 0);
                          break;
                      case 100: 
                          color = new Color(0, 0, 1);
                          break;
                  }
               //   mapColorList.Add(color);
                  mapColorArray[i] = color;

              }
            //  mapColorArray = new Color[mapColorList.Count];
          //    mapColorArray = mapColorList.ToArray();
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