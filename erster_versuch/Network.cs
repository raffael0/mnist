using System;
using System.Collections.Generic;
using System.Linq;

namespace erster_versuch
{
    public class Network
    {
        private List<Layer> layers;
        public Network(int inputs, int outputs, int hidden_layers, int hidden_layer_size) { 
            layers = new List<Layer>(2+hidden_layers);
            layers.Insert(0,new Layer(inputs));
            for (int i = 0; i < hidden_layers; i++)
            {
                layers.Add(new Layer(hidden_layer_size)) ;
            }
            layers.Add(new Layer(outputs));

        }

        public void cycle(List<Image> images)
        {
            for (int i = 0; i < 10; i++)
            {
                Iterate(images[i].Inputs.ToList());
                Print();
                Console.Write("/n /n /n");
            }
        }
        public void Iterate(List<double> inputs)
        {
            layers[0].CalculateValues(null,inputs);
            for (int i = 1; i < layers.Count; i++)
            {
                layers[i].CalculateValues(layers[i-1]);
            }
        }
        private float  DotProduct(float input_value, float weight)
        {
            return input_value * weight;
        }

        public void Print()
        {
            
            for (int i = 0; i < layers.Count; i++)
            {
                Console.WriteLine("Layer: " + i + ";   " +layers[i].ToString());
            }
        }
    }
}