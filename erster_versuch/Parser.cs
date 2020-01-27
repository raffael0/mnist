using System;
using System.Collections.Generic;
using System.IO;

namespace erster_versuch
{
    public class Parser
    {
        public Parser()
        {
            Images = new List<Image>();
        }
        public List<Image> Images { get; set; }

        public void Parse(string  imageFile, string labelFile )
        {
            byte[] labels = File.ReadAllBytes(labelFile);
            byte[] images = File.ReadAllBytes(imageFile);
            List<Image> imageList = new List<Image>();
            for (int i = 0; i < 60000; i++)
            {
                Image image = new Image();
                image.LabelValue = labels[8 + i];
                for (int j = 0; j < 784; j++)
                {
                    image.Inputs[j] = images[16 + i * 784 + j];
                }
                imageList.Add(image);
            }

            Images = imageList;
        }
    }
}