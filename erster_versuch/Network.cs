using System;
using System.Collections.Generic;
using System.Linq;

namespace erster_versuch
{
    public class Network
    {
        private List<Layer> _layers;
        private double learningRate = 1;
        public Network(int inputs, int outputs, int hiddenLayers, int hiddenLayerSize) { 
            _layers = new List<Layer>(2+hiddenLayers);
            _layers.Insert(0,new Layer(inputs,0,learningRate));
            for (int i = 1; i < hiddenLayers+1; i++)
            {
                _layers.Add(new Layer(hiddenLayerSize,i,learningRate)) ;
            }
            _layers.Add(new Layer(outputs,_layers.Count,learningRate));

        }

        public void Cycle(List<Image> images)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Step: " + i);
                Iterate(images[i].Inputs.ToList());

                Console.WriteLine("Cost:" + back_propagate(images[i].LabelValue));
                Print();
                Console.Write(Environment.NewLine + Environment.NewLine + Environment.NewLine);
            }
        }

        private void Iterate(List<double> inputs)
        {
            _layers[0].CalculateValues(null,inputs);
            for (var i = 1; i < _layers.Count-1; i++)
            {
                _layers[i].CalculateValues(_layers[i]);
            }
        }
        public double back_propagate(double label)
        {
            
            var cost = _layers[^1].CalculateCost(label);
            for (var i = _layers.Count-1; i > 1; i--)
            {
                _layers[i].BackPropagate(cost);
            }

            return cost;
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
