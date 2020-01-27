using System;
using System.Collections.Generic;
using System.Linq;

namespace erster_versuch
{
    public class Network
    {
        private List<Layer> _layers;
        public Network(int inputs, int outputs, int hiddenLayers, int hiddenLayerSize) { 
            _layers = new List<Layer>(2+hiddenLayers);
            _layers.Insert(0,new Layer(inputs,0));
            for (int i = 1; i < hiddenLayers+1; i++)
            {
                _layers.Add(new Layer(hiddenLayerSize,i)) ;
            }
            _layers.Add(new Layer(outputs,_layers.Count));

        }

        public void Cycle(List<Image> images)
        {
            for (int i = 0; i < 10; i++)
            {
                Iterate(images[i].Inputs.ToList());
                Print();
                Console.Write(Environment.NewLine + Environment.NewLine + Environment.NewLine);
            }
        }
        public void Iterate(List<double> inputs)
        {
            _layers[0].CalculateValues(null,inputs);
            for (int i = 1; i < _layers.Count; i++)
            {
                _layers[i].CalculateValues(_layers[i-1]);
            }
        }
        private float  DotProduct(float inputValue, float weight)
        {
            return inputValue * weight;
        }

        public void back_propagate(int layer)
        {
            var cost = _layers[^1].CalculateCost(layer);
            for (int i = 0; i < _layers.Count; i++)
            {
                _layers[i].BackPropagate(layer,_layers.Count);
            }
        }
        private void Print()
        {
            
            for (int i = 0; i < _layers.Count; i++)
            {
                Console.WriteLine("Layer: " + i + ";   " +_layers[i].ToString());
                Console.Write(Environment.NewLine);

            }
        }
    }
}
