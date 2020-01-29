using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;

namespace erster_versuch
{
    public class Layer
    {
        public List<Neuron> Neurons { get; }
        public int Index { get; }
        private double learningRate;

        public Layer(int capacity, int index, double learningRate)
        {
            Index = index;
            this.learningRate = learningRate;

            Neurons = new List<Neuron>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Neurons.Add(new Neuron(capacity));
            }
        }

        public void CalculateValues(Layer prevLayer = null, List<double> inputs = null)
        {
            if (Index == 0)
            {
                for (var i = 0; i < Neurons.Count; i++)
                {
                    Neurons[i].Value = inputs[i];
                }
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(ToString());
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(Environment.NewLine);
            }
            else
            {
                foreach (var neuron in Neurons)
                {
                    neuron.calculate_value(prevLayer);
                }
            }
            

        }

        public double CalculateCost(double label)
        {
            return Neurons.Select((t, i) => Math.Pow(t.Value - (label == i ? 0 : 1), 2)).Sum();
        }    
        public void BackPropagate( double cost)
        {
            foreach (var neuron in Neurons)
            {
                    neuron.Bias  -= ((cost / neuron.Value) * (neuron.Value / neuron.NetValue) * (neuron.NetValue / neuron.Bias));
                    
                    for (var j = 0; j < neuron.Weights.Count; j++)
                    {
                        neuron.Weights[j] -= (cost / neuron.Value) * (neuron.Value / neuron.NetValue) *
                                             (neuron.NetValue / neuron.Weights[j]);
                    }
            } 
        }
        public override string ToString()
        {
            string s = "{";
            foreach (var neuron in Neurons)
            {
                s += neuron.ToString() + ";";
            }

            s += "};";
            return s;
        }
    }
}